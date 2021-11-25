namespace ProductShop
{
    using Microsoft.EntityFrameworkCore;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using ProductShop.XmlConvertHelper;
    using System;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        private const string DATASETS_DIRECTORY_PATH = "../../../Datasets";

        public static void Main(string[] args)
        {
            var contextDb = new ProductShopContext();

            using (contextDb)
            {
                // Problem 01 - Import Users
                //ResetDataBase(contextDb);
                //var inputXml = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/users.xml");
                //Console.WriteLine(ImportUsers(contextDb, inputXml));

                // Problem 02 - Import Products
                //var inputXml = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/products.xml");
                //Console.WriteLine(ImportProducts(contextDb, inputXml));

                // Problem 03 - Import Categories
                //var inputXml = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/categories.xml");
                //Console.WriteLine(ImportCategories(contextDb, inputXml));

                // Problem 04 - Import Categories and Products
                //var inputXml = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/categories-products.xml");
                //Console.WriteLine(ImportCategoryProducts(contextDb, inputXml));

                // Problem 05 - Export Products In Range
                //Console.WriteLine(GetProductsInRange(contextDb));

                // Problem 06 - Export Sold Products
                //Console.WriteLine(GetSoldProducts(contextDb));

                // Problem 07 - Export Categories By Products Count
                //Console.WriteLine(GetCategoriesByProductsCount(contextDb));

                // Problem 08 - Export Users and Products
                Console.WriteLine(GetUsersWithProducts(contextDb));
            }
        }

        // Problem 08 - Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var rootEl = "Users";

            var uasersAndProducts = context.Users
                 .Include(u => u.ProductsSold)
                 .ToArray()
                 .Where(u => u.ProductsSold.Count > 0)
                 .OrderByDescending(u => u.ProductsSold.Count)
                 .Select(u => new OutputUserDto
                 {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Age = u.Age,
                     SoldProduct = new OutputProductCountDto
                     {
                         Count = u.ProductsSold.Count(),
                         Products = u.ProductsSold.Select(cp => new OuputProductDto
                         {
                             Name = cp.Name,
                             Price = cp.Price
                         })
                         .OrderByDescending(p => p.Price)
                         .ToArray()
                     }

                 })
                 .ToArray();

            var resultCount = new UsersCountOutput
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = uasersAndProducts.Take(10).ToArray()
            };


            var result = XmlConverter.Serialize(resultCount, rootEl);

            return result;
        }

        // Problem 07 - Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var rootEl = "Categories";

            var categories = context.Categories
                .Select(c => new CategoryOutputModel
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)

                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            return XmlConverter.Serialize(categories, rootEl);
        }

        // Problem 06 - Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootEl = "Users";

            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new UsersSoldProductsOutputModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(ps => new UserProductOutputModel
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    })
                    .ToArray()
                })
                .ToList();

            return XmlConverter.Serialize(users, rootEl);
        }

        // Problem 05 - Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootEl = "Products";

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ProductOutputModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToList();

            return XmlConverter.Serialize(products, rootEl);
        }

        // Problem 04 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string rootEl = "CategoryProducts";

            var categoriesProductsInput = XmlConverter.Deserializer<CategoryProductInputModel>(inputXml, rootEl);

            var categoriesProducts = categoriesProductsInput
                .Where(cp => context.Categories.Any(c => c.Id == cp.CategoryId) &&
                             context.Products.Any(p => p.Id == cp.ProductId))
                .Select(cp => new CategoryProduct
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                })
                .ToList();

            context.CategoryProducts.AddRange(categoriesProducts);
            int categoryProductsCount = context.SaveChanges();

            return $"Successfully imported {categoryProductsCount}";
        }

        // Problem 03 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootEl = "Categories";

            var categoriesInput = XmlConverter.Deserializer<CategoryInputModel>(inputXml, rootEl);

            var categories = categoriesInput
                .Where(c => c.Name != null)
                .Select(c => new Category
                {
                    Name = c.Name
                })
                .ToList();

            context.Categories.AddRange(categories);
            int categoriesCount = context.SaveChanges();

            return $"Successfully imported {categoriesCount}";
        }

        // Problem 02 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootEl = "Products";

            var productsInput = XmlConverter.Deserializer<ProductInputModel>(inputXml, rootEl);

            var products = productsInput
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                })
                .ToList();

            context.Products.AddRange(products);
            int productsCount = context.SaveChanges();

            return $"Successfully imported {productsCount}";
        }

        // Problem 01 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootEl = "Users";

            var usersInput = XmlConverter.Deserializer<UserInputModel>(inputXml, rootEl);

            var users = usersInput
                .Select(u => new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                })
                .ToList();

            context.Users.AddRange(users);
            int usersCount = context.SaveChanges();

            return $"Successfully imported {usersCount}";
        }

        public static void ResetDataBase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Your DB has been deleted");
            db.Database.EnsureCreated();
            Console.WriteLine("Your DB has been created");

        }
    }
}