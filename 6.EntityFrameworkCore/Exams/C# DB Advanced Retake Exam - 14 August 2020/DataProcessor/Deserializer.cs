namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<ImportDepartmentsAndCellsJsonDto> dtos =
                JsonConvert.DeserializeObject<IEnumerable<ImportDepartmentsAndCellsJsonDto>>(jsonString);

            HashSet<Department> departments = new HashSet<Department>();

            foreach (var department in dtos)
            {
                bool flag = false;

                if (!IsValid(department) || department.Cells.Count() == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department d = new Department
                {
                    Name = department.Name,
                };

                foreach (var cell in department.Cells)
                {
                    if (cell.CellNumber < 1 || cell.CellNumber > 1000)
                    {
                        sb.AppendLine("Invalid Data");
                        flag = true;
                        break;
                    }

                    Cell c = new Cell
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow,
                    };

                    d.Cells.Add(c);
                }

                if (flag)
                {
                    continue;
                }

                departments.Add(d);
                sb.AppendLine($"Imported {d.Name} with {d.Cells.Count()} cells");
            }

            context.AddRange(departments);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<ImportPrisonersAndMailsJsonDto> dtos = JsonConvert.DeserializeObject<IEnumerable<ImportPrisonersAndMailsJsonDto>>(jsonString);
            HashSet<Prisoner> prisoners = new HashSet<Prisoner>();

            foreach (var prisoner in dtos)
            {
                if (!IsValid(prisoner))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isIncarcerationDateDateValid = DateTime.TryParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var incarcerationDateDate);

                bool isReleaseDateValid = DateTime.TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate);

                if (!isIncarcerationDateDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Prisoner p = new Prisoner
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = incarcerationDateDate,
                    ReleaseDate = releaseDate,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId
                };

                bool flag = false;

                foreach (var mail in prisoner.Mails)
                {
                    if (!IsValid(mail))
                    {
                        sb.AppendLine("Invalid Data");
                        flag = true;
                        break;
                    }

                    Mail m = new Mail
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address
                    };

                    p.Mails.Add(m);
                }

                if (flag)
                {
                    continue;
                }

                prisoners.Add(p);
                sb.AppendLine($"Imported {p.FullName} {p.Age} years old");
            }

            context.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportOfficersAndPrisonersXmlDto[]),
                new XmlRootAttribute("Officers"));

            ImportOfficersAndPrisonersXmlDto[] dtos = (ImportOfficersAndPrisonersXmlDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            HashSet<Officer> officers = new HashSet<Officer>();

            foreach (var officer in dtos)
            {
                if (!IsValid(officer))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isWeaponValid = Enum.IsDefined(typeof(Weapon), officer.Weapon);
                bool isPositionValid = Enum.IsDefined(typeof(Position), officer.Position);
                
                if (!isWeaponValid || !isPositionValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var weapon = Enum.Parse(typeof(Weapon), officer.Weapon);
                var position = Enum.Parse(typeof(Position),officer.Position);

                Officer o = new Officer
                {
                    FullName = officer.Name,
                    Salary = officer.Money,
                    Position = (Position)position,
                    Weapon = (Weapon)weapon,
                    DepartmentId = officer.DepartmentId,
                };

                foreach (var prisoner in officer.Prisoners)
                {
                    OfficerPrisoner op = new OfficerPrisoner
                    {
                        Officer = o,
                        PrisonerId = prisoner.Id
                    };

                    o.OfficerPrisoners.Add(op);
                }

                sb.AppendLine($"Imported {o.FullName} ({o.OfficerPrisoners.Count} prisoners)");
                officers.Add(o);
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}