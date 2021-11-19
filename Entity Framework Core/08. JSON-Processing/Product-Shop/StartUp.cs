using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Datasets.DtoModels.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private const string DATASETS_DIRECTORY_PATH = "../../../Datasets";

        public static void Main(string[] args)
        {
            var contextDb = new ProductShopContext();

            using (contextDb)
            {
                InitializeMapper();

                // Problem 01 - Import Users
                //ResetDatabase(contextDb);
                //var inputJson = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/users.json");
                //Console.WriteLine(ImportUsers(contextDb, inputJson));

                // Problem 02 - Import Products
                //var inputJson = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/products.json");
                //Console.WriteLine(ImportProducts(contextDb, inputJson));

                // Problem 03 - Import Categories
                // var inputJson = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/categories.json");
                // Console.WriteLine(ImportCategories(contextDb, inputJson));

                // Problem 04 - Import Categories and Products
                // var inputJson = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/categories-products.json");
                // Console.WriteLine(ImportCategoryProducts(contextDb, inputJson));

                // Problem 05 - Export Products in Range
                //var json = GetProductsInRange(contextDb);Console.WriteLine(GetProductsInRange(contextDb));

                // Problem 06 - Export Successfully Sold Products
                //Console.WriteLine(GetSoldProducts(contextDb));

                // Problem 07 - Export Categories By Products Count
                //Console.WriteLine(GetCategoriesByProductsCount(contextDb));

                //Problem 08 - Export Users and Products
                Console.WriteLine(GetUsersWithProducts(contextDb));
            }
        }

        //Problem 08 - Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .AsEnumerable()
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count,
                        products = u.ProductsSold.Select(ps => new
                        {
                            name = ps.Name,
                            price = $"{ps.Price:F2}"
                        })
                        .ToList()
                    }
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToList();

            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var result = new
            {
                usersCount = usersWithProducts.Count,
                users = usersWithProducts
            };

            return JsonConvert.SerializeObject(result, jsonSettings);
        }

        // Problem 07 - Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = $"{c.CategoryProducts.Average(cp => cp.Product.Price):F2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(cp => cp.Product.Price):F2}"
                })
                .ToList();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        // Problem 06 - Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1 &&
                            u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLastName = ps.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        // Problem 05 - Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.price)
                .ToList();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        // Problem 04 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // Problem 03 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<CategoryInputDto>>(inputJson);

            var categoriesToImport = new List<Category>(categories.Count);

            foreach (var inputDto in categories)
            {
                if (inputDto.Name != null)
                {
                    var newCategory = Mapper.Map<Category>(inputDto);
                    categoriesToImport.Add(newCategory);
                }
            }

            context.Categories.AddRange(categoriesToImport);
            context.SaveChanges();

            return $"Successfully imported {categoriesToImport.Count}";
        }

        // Problem 02 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<ProductInputDto>>(inputJson);

            var productsToImpoort = new List<Product>(products.Count);

            foreach (var inputDto in products)
            {
                if (inputDto.Name.Length >= 3)
                {
                    Product newProduct = Mapper.Map<Product>(inputDto);
                    productsToImpoort.Add(newProduct);
                }
            }

            context.Products.AddRange(productsToImpoort);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        // Problem 01 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            var usersDto = JsonConvert.DeserializeObject<List<UserInputDto>>(inputJson, jsonSettings);

            var users = usersDto
                .Select(dto => Mapper.Map<User>(dto))
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        // Empty Database
        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Db was successfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Db was successfully created!");
        }

        // Initializing the Mapper
        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
        }
    }
}