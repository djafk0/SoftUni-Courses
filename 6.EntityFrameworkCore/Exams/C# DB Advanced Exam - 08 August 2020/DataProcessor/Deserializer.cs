namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var games = JsonConvert.DeserializeObject<IEnumerable<ImportGamesJsonDto>>(jsonString);

            foreach (var jsonGame in games)
            {
                if (!IsValid(jsonGame) || jsonGame.Tags.Count() == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var genre = context.Genres.FirstOrDefault(g => g.Name == jsonGame.Genre)
                    ?? new Genre { Name = jsonGame.Genre };

                var developer = context.Developers.FirstOrDefault(d => d.Name == jsonGame.Developer)
                    ?? new Developer { Name = jsonGame.Developer };

                Game game = new Game
                {
                    Name = jsonGame.Name,
                    Genre = genre,
                    Developer = developer,
                    Price = jsonGame.Price,
                    ReleaseDate = jsonGame.ReleaseDate.Value,
                };

                foreach (var jsonTag in jsonGame.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(t => t.Name == jsonTag)
                        ?? new Tag { Name = jsonTag };
                    game.GameTags.Add(new GameTag { Tag = tag });
                }

                context.Games.Add(game);
                context.SaveChanges();
                sb.AppendLine($"Added {jsonGame.Name} ({jsonGame.Genre}) with {jsonGame.Tags.Count()} tags");
            }

            return sb.ToString();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var users = JsonConvert.DeserializeObject<IEnumerable<ImportUsersJsonDto>>(jsonString);

            foreach (var userJson in users)
            {
                if (!IsValid(userJson))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                User user = new User
                {
                    Username = userJson.Username,
                    FullName = userJson.FullName,
                    Age = userJson.Age,
                    Email = userJson.Email,
                };

                foreach (var cardJson in userJson.Cards)
                {
                    Card card = new Card
                    {
                        Number = cardJson.Number,
                        Cvc = cardJson.Cvc,
                        Type = cardJson.Type.Value
                    };

                    user.Cards.Add(card);
                }

                context.Users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count()} cards");
            }

            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportPurchasesXmlDto[]),
                new XmlRootAttribute("Purchases"));

            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            ImportPurchasesXmlDto[] purchasesDto = (ImportPurchasesXmlDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var parsedDate = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

                if (!parsedDate)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Purchase purchase = new Purchase
                {
                    Type = purchaseDto.Type.Value,
                    ProductKey = purchaseDto.Key,
                    Date = date,
                    Card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card),
                    Game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title)
                };

                var user = context.Users.Where(x => x.Id == purchase.Card.UserId).Select(q => q.Username).FirstOrDefault();

                context.Purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {user}");
            }

            context.SaveChanges();
            return sb.ToString();
        }


        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}