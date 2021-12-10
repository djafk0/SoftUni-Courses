namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = 
                new XmlSerializer(typeof(ImportPlaysXmlDto[]),
                new XmlRootAttribute("Plays"));

            ImportPlaysXmlDto[] dtos = (ImportPlaysXmlDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            HashSet<Play> plays = new HashSet<Play>();

            foreach (var play in dtos)
            {
                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidDuration = TimeSpan.TryParseExact(play.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out var duration);
                bool isValidGenre = Enum.IsDefined(typeof(Genre), play.Genre);

                if (!isValidDuration || !isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var genre = Enum.Parse(typeof(Genre), play.Genre);

                Play p = new Play
                {
                    Title = play.Title,
                    Duration = duration,
                    Rating = play.Rating,
                    Genre = (Genre)genre,
                    Description = play.Description,
                    Screenwriter = play.Screenwriter
                };

                sb.AppendLine($"Successfully imported {p.Title} with genre {p.Genre} and a rating of {p.Rating}!");
                plays.Add(p);
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = 
                new XmlSerializer(typeof(ImportCastsXmlDto[]), 
                new XmlRootAttribute("Casts"));

            ImportCastsXmlDto[] dtos = (ImportCastsXmlDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            HashSet<Cast> casts = new HashSet<Cast>();

            foreach (var cast in dtos)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast c = new Cast
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId
                };

                string mainOrLesser = c.IsMainCharacter ? "main" : "lesser";

                sb.AppendLine($"Successfully imported actor {c.FullName} as a {mainOrLesser} character!");
                casts.Add(c);
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<ImportTheatresAndTicketsJsonDto> dtos = JsonConvert.DeserializeObject<IEnumerable<ImportTheatresAndTicketsJsonDto>>(jsonString);
            HashSet<Theatre> theatres = new HashSet<Theatre>();

            foreach (var theatre in dtos)
            {
                if (!IsValid(theatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre t = new Theatre
                {
                    Name = theatre.Name,
                    NumberOfHalls = theatre.NumberOfHalls,
                    Director = theatre.Director,
                };

                HashSet<Ticket> tickets = new HashSet<Ticket>();

                foreach (var ticket in theatre.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket tt = new Ticket
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    };

                    tickets.Add(tt);
                }

                t.Tickets = tickets;
                theatres.Add(t);
                sb.AppendLine($"Successfully imported theatre {t.Name} with #{tickets.Count} tickets!");
            }

            context.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
