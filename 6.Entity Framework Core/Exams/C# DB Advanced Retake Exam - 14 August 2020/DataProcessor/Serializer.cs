namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var result = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .ToArray()
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(po => new
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                    .OrderBy(po => po.OfficerName),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] splittedInput = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var result = context
                .Prisoners
                .Where(p => splittedInput.Contains(p.FullName))
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails.Select(m => new ExportMessageDto
                    {
                        Description = new string (m.Description.Reverse().ToArray())
                    }).ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();



            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportPrisonerDto[]),
                new XmlRootAttribute("Prisoners"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sw = new StringWriter();

            xmlSerializer.Serialize(sw, result, namespaces);

            return sw.ToString();
        }
    }
}