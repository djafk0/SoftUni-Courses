using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.input;
using ProductShop.Dtos.UserInputDto;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string usersJsonAsString = File.ReadAllText("../../../Datasets/users.json");
            //string productsJsonAsString = File.ReadAllText("../../../Datasets/products.json");
            //string categoryJsonAsString = File.ReadAllText("../../../Datasets/categories.json");
            //string categoryProductJsonAsString = File.ReadAllText("../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportUsers(context, usersJsonAsString));
            //Console.WriteLine(ImportProducts(context, productsJsonAsString));
            //Console.WriteLine(ImportCategories(context, categoryJsonAsString));
            //Console.WriteLine(ImportCategoryProducts(context, categoryProductJsonAsString));
            //GetProductsInRange(context);
            //GetSoldProducts(context);
            //GetCategoriesByProductsCount(context);
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<UserInputDto> users = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            cfg.AddProfile<ProductShopProfile>());

            IMapper mapper = new Mapper(mapperConfiguration);

            IEnumerable<User> mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<ProductInputDto> products = JsonConvert.DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            cfg.AddProfile<ProductShopProfile>());

            IMapper mapper = new Mapper(mapperConfiguration);

            IEnumerable<Product> mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();
            return $"Successfully imported {mappedProducts.Count()}";

        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryInputDto> categories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputDto>>(inputJson)
                .Where(c => !string.IsNullOrEmpty(c.Name));

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            cfg.AddProfile<ProductShopProfile>());

            IMapper mapper = new Mapper(mapperConfiguration);

            IEnumerable<Category> mappedCategories = mapper.Map<IEnumerable<Category>>(categories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryProductsInputDto> categoryProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductsInputDto>>(inputJson);

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            cfg.AddProfile<ProductShopProfile>());

            IMapper mapper = new Mapper(mapperConfiguration);

            IEnumerable<CategoryProduct> mappedCategoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProducts);

            context.CategoryProducts.AddRange(mappedCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedCategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var result = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .ToArray();

            DefaultContractResolver defaultContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = defaultContractResolver
            };

            string produstAsJson = JsonConvert.SerializeObject(result, jsonSettings);


            return produstAsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var result = context
                .Users
                .Include(p => p.ProductsSold)
                .Where(p => p.ProductsSold.Any(q => q.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                    .Select(q => new
                    {
                        Name = q.Name,
                        Price = q.Price,
                        BuyerFirstName = q.Buyer.FirstName,
                        BuyerLastName = q.Buyer.LastName
                    })
                    .ToArray()
                })
                .ToArray();

            DefaultContractResolver defaultContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = defaultContractResolver
            };

            string resultAsJson = JsonConvert.SerializeObject(result, jsonSettings);

            return resultAsJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var result = context
                .Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price).ToString("F2")
                })
                .ToArray();

            DefaultContractResolver defaultContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = defaultContractResolver
            };

            string resultAsJson = JsonConvert.SerializeObject(result, jsonSettings);

            return resultAsJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                .Include(u => u.ProductsSold)
                .ToArray()
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Count(),
                        products = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                        .ToList()
                    }

                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToList();


            var withUserCount = new
            {
                usersCount = users.Count,
                users,

            };

            var json = JsonConvert.SerializeObject(withUserCount, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
            return json;
        }
    }
}