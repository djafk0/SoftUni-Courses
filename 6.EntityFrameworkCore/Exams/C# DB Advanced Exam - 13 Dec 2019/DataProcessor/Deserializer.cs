namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportBookXmlDto[]),
                new XmlRootAttribute("Books"));

            ImportBookXmlDto[] dtos = (ImportBookXmlDto[])serializer.Deserialize(new StringReader(xmlString));
            HashSet<Book> books = new HashSet<Book>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                bool isValidPublishedOn = DateTime.TryParseExact(dto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

                if (!isValidPublishedOn)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Book book = new Book
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Pages = dto.Pages,
                    PublishedOn = date,
                    Genre = (Genre)dto.Genre,
                };

                books.Add(book);
                sb.AppendLine($"Successfully imported book {book.Name} for {book.Price:f2}.");
            }

            context.Books.AddRange(books);
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var emails = context.Authors.Select(a => a.Email).ToList();
            var bookIds = context.Books.Select(b => b.Id).ToArray();

            IEnumerable<ImportAuthorJsonDto> authorsDto = JsonConvert.DeserializeObject<IEnumerable<ImportAuthorJsonDto>>(jsonString);

            HashSet<Author> authors = new HashSet<Author>();

            foreach (var authorDto in authorsDto)
            {
                if (!IsValid(authorDto) || emails.Contains(authorDto.Email))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                emails.Add(authorDto.Email);

                Author author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone,
                };

                HashSet<AuthorBook> authorBooks = new HashSet<AuthorBook>();

                foreach (var bookDto in authorDto.Books)
                {
                    if (!IsValid(bookDto))
                    {
                        continue;
                    }

                    if (!bookIds.Contains(bookDto.Id.Value) || bookDto.Id == null)
                    {
                        continue;
                    }

                    AuthorBook authorBook = new AuthorBook
                    {
                        Author = author,
                        BookId = bookDto.Id.Value
                    };

                    authorBooks.Add(authorBook);
                }

                if (authorBooks.Count() == 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                author.AuthorsBooks = authorBooks;
                authors.Add(author);
                sb.AppendLine($"Successfully imported author - {author.FirstName + " " + author.LastName} with {authorBooks.Count()} books.");
            }

            context.Authors.AddRange(authors);
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