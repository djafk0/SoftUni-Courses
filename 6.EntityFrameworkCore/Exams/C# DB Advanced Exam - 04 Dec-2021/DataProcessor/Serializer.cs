namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var result = context
                .Theatres
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .OrderByDescending(t => t.NumberOfHalls)
                .ThenBy(t => t.Name)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(tt => tt.RowNumber >= 1 && tt.RowNumber <= 5).Sum(ttt => ttt.Price),
                    Tickets = t.Tickets
                    .ToArray()
                    .Where(tt => tt.RowNumber >= 1 && tt.RowNumber <= 5)
                    .Select(tt => new
                    {
                        Price = tt.Price,
                        RowNumber = tt.RowNumber
                    })
                    .OrderByDescending(tt => tt.Price)
                    .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var result = context
                .Plays
                .Where(p => p.Rating <= rating)
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .Select(p => new ExportPlaysXmlDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating.ToString() == "0" ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                    .Where(c => c.IsMainCharacter == true)
                    .OrderByDescending(c => c.FullName)
                    .Select(c => new ExportActorXmlDto
                    {
                        FullName = c.FullName,
                        MainCharacter = new string($"Plays main character in '{p.Title}'.").ToString()
                    })
                    .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportPlaysXmlDto[]),
                new XmlRootAttribute("Plays"));

            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), result, xmlSerializerNamespaces);

            return sb.ToString();
        }
    }
}
