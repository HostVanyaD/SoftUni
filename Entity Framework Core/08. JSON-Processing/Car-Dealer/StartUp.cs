using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private const string DATASETS_DIRECTORY_PATH = "../../../Datasets";

        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();

            using (dbContext)
            {
                //ResetDatabase(dbContext);
                InitializeMapper();

                // Problem 09 - Import Suppliers
                //var inputJson = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/suppliers.json");
                //Console.WriteLine(ImportSuppliers(dbContext, inputJson));

                // Problem 10 - Import Parts
                //var inputJson1 = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/parts.json");
                //Console.WriteLine(ImportParts(dbContext, inputJson1));

                // Problem 11 - Import Cars
                //var inputJson2 = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/cars.json");
                //Console.WriteLine(ImportCars(dbContext, inputJson2));

                // Problem 12 - Import Customers
                //var inputJson = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/customers.json");
                //Console.WriteLine(ImportCustomers(dbContext, inputJson));

                // Problem 13 - Import Sales
                //var inputJson = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/sales.json");
                //Console.WriteLine(ImportSales(dbContext, inputJson));

                // Problem 14 - Export Ordered Customers
                //Console.WriteLine(GetOrderedCustomers(dbContext));

                // Problem 15 - Export Cars From Make Toyota
                //Console.WriteLine(GetCarsFromMakeToyota(dbContext));

                // Problem 16 - Export Local Suppliers
                //Console.WriteLine(GetLocalSuppliers(dbContext));                

                //Problem 17 - Export Cars With Their List Of Parts
                //Console.WriteLine(GetCarsWithTheirListOfParts(dbContext));

                //Problem 18 - Export Total Sales By Customer
                //Console.WriteLine(GetTotalSalesByCustomer(dbContext));

                //Problem 19 - Export Sales With Applied Discount
                Console.WriteLine(GetSalesWithAppliedDiscount(dbContext));
            }
        }

        //Problem 19 - Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("F2"),
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("F2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) * ((100 - s.Discount) / 100))
                                        .ToString("F2")
                })
                .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        //Problem 18 - Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s =>
                          s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        //Problem 17 - Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("F2")
                    })
                    .ToList()
                })
                .ToList();


            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        // Problem 16 - Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .OrderBy(c => c.Id)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    PartsCount = c.Parts.Count
                });

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        // Problem 15 - Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsByToyota = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                });

            return JsonConvert.SerializeObject(carsByToyota, Formatting.Indented);
        }

        // Problem 14 - Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var custmers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    c.BirthDate,
                    c.IsYoungDriver
                });

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatString = "dd/MM/yyyy"
            };

            return JsonConvert.SerializeObject(custmers, jsonSettings);
        }

        // Problem 13 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        // Problem 12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        // Problem 11 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDtos = JsonConvert.DeserializeObject<List<CarInputModel>>(inputJson);

            var carsToImport = new List<Car>(carsDtos.Count);

            foreach (var car in carsDtos)
            {
                var newCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    newCar.PartCars.Add(new PartCar { PartId = partId });
                }

                carsToImport.Add(newCar);
            }

            context.Cars.AddRange(carsToImport);
            context.SaveChanges();

            return $"Successfully imported {carsToImport.Count}.";
        }

        // Problem 10 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        // Problem 09 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        // Empty Database
        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Db was successfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Db was successfully created!");
        }

        // Initializing Mapper
        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
        }
    }
}