using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();


            //string userXml = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(dbContext, userXml));

            //string productXml = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(dbContext, productXml));

            //string categoryXml = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(dbContext, categoryXml));

            //string categoryProductXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(dbContext, categoryProductXml));

            //Console.WriteLine(GetProductsInRange(dbContext));
            //Console.WriteLine(GetSoldProducts(dbContext));
            //Console.WriteLine(GetCategoriesByProductsCount(dbContext));
            Console.WriteLine(GetUsersWithProducts(dbContext));

        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[])
                , new XmlRootAttribute("Users"));

            using StringReader stringReader = new StringReader(inputXml);

            ImportUserDto[] dtos = (ImportUserDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<User> users = new HashSet<User>();

            foreach (ImportUserDto userDto in dtos)
            {
                User user = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age,
                };

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));
            using StringReader stringReader = new StringReader(inputXml);

            ImportProductDto[] dtos = (ImportProductDto[])serializer.Deserialize(stringReader);

            ICollection<Product> products = new HashSet<Product>();

            foreach (ImportProductDto productDto in dtos)
            {
                Product product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    BuyerId = productDto.BuyerId,
                    SellerId = productDto.SellerId,
                };

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));
            using StringReader stringReader = new StringReader(inputXml);

            ImportCategoryDto[] dtos = (ImportCategoryDto[])serializer.Deserialize(stringReader);

            ICollection<Category> categories = new HashSet<Category>();

            foreach (ImportCategoryDto categoryDto in dtos)
            {
                Category category = new Category()
                {
                    Name = categoryDto.Name
                };

                if (category.Name == null)
                {
                    continue;
                }

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));
            using StringReader stringReader = new StringReader(inputXml);

            ImportCategoryProductDto[] dtos = (ImportCategoryProductDto[])serializer.Deserialize(stringReader);

            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();

            foreach (ImportCategoryProductDto categoryProductDto in dtos)
            {
                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = categoryProductDto.CategoryId,
                    ProductId = categoryProductDto.ProductId
                };

                int[] productIds = context
                    .Products
                    .Select(p => p.Id)
                    .ToArray();

                int[] categoryIds = context
                    .Categories
                    .Select(c => c.Id)
                    .ToArray();

                if (!categoryIds.Contains(categoryProduct.CategoryId))
                {
                    continue;
                }

                if (!productIds.Contains(categoryProduct.ProductId))
                {
                    continue;
                }

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProductsInRangeDto[]), new XmlRootAttribute("Products"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportProductsInRangeDto[] dtos = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName,
                })
                .ToArray();

            serializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSoldProductsWtihNamesDto[]), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportSoldProductsWtihNamesDto[] dtos = context
                .Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportSoldProductsWtihNamesDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Select(q => new DExport
                    {
                        Name = q.Name,
                        Price = q.Price
                    })
                    .ToArray()
                })
                .ToArray();

            serializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCategoriesByProductsCountDto[]), new XmlRootAttribute("Categories"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportCategoriesByProductsCountDto[] dtos = context
                .Categories
                .Select(c => new ExportCategoriesByProductsCountDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cc => cc.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cc => cc.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            serializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(AExport),
                new XmlRootAttribute("Users"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var dtos = context
                .Users
                .ToArray()
                .Where(a => a.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(b => new BExport
                {
                    Age = b.Age,
                    FirstName = b.FirstName,
                    LastName = b.LastName,
                    Products = new CExport
                    {
                        Count = b.ProductsSold.Count,
                        Products = b.ProductsSold
                        .Select(ps => new DExport
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .OrderByDescending(b => b.Price)
                        .ToArray()
                    }
                })
                .ToArray();

            var finalDto = new AExport
            {
                Count = dtos.Length,
                Users = dtos.Take(10).ToArray()
            };

            xmlSerializer.Serialize(stringWriter, finalDto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}