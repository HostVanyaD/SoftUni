namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTO.Input;
    using CarDealer.DTO.Output;
    using CarDealer.Models;
    using CarDealer.XMLConvertHelper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        private const string DATASETS_DIRECTORY_PATH = "../../../Datasets";

        static IMapper mapper;

        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();

            using (dbContext)
            {
                // Problem 09. Import Suppliers
                //ResetDatabase(dbContext);
                //var inputXml = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/suppliers.xml");
                //Console.WriteLine(ImportSuppliers(dbContext, inputXml));

                // Problem 10. Import Parts
                //var inputXml = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/parts.xml");
                //Console.WriteLine(ImportParts(dbContext, inputXml));

                // Problem 11. Import Cars
                //var inputXml = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/cars.xml");
                //Console.WriteLine(ImportCars(dbContext, inputXml));

                // Problem 12. Import Customers
                //var inputXml = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/customers.xml");
                //Console.WriteLine(ImportCustomers(dbContext, inputXml));

                // Problem 13. Import Sales
                //var inputXml = File.ReadAllText($"{DATASETS_DIRECTORY_PATH}/sales.xml");
                //Console.WriteLine(ImportSales(dbContext, inputXml));

                // Problem 14. Export Cars With Distance
                //Console.WriteLine(GetCarsWithDistance(dbContext));

                // Problem 15. Export Cars From Make BMW
                //Console.WriteLine(GetCarsFromMakeBmw(dbContext));

                // Problem 16. Export Local Suppliers
                //Console.WriteLine(GetLocalSuppliers(dbContext));

                // Problem 17. Export Cars With Their List Of Parts
                //Console.WriteLine(GetCarsWithTheirListOfParts(dbContext));

                // Problem 18. Export Total Sales By Customer
                //Console.WriteLine(GetTotalSalesByCustomer(dbContext));

                // Problem 19. Export Sales With Applied Discount
                Console.WriteLine(GetSalesWithAppliedDiscount(dbContext));
            }
        }

        // Problem 19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            const string rootEl = "sales";

            var salesWithDiscount = context.Sales
                .Select(s => new SaleWithDiscountOutputDto
                {
                    Car = new CarWithDiscountOutputDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(p => p.Part.Price) -
                                        s.Car.PartCars.Sum(p => p.Part.Price) *
                                        s.Discount / 100
                })
                .ToList();

            return XMLConverter.Serialize(salesWithDiscount, rootEl);
        }

        // Problem 18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string rootEl = "customers";

            var customers = context.Sales
                .Where(s => s.Car.Sales.Any())
                .Select(s => new CustomerWithTotalSalesOutputDto
                {
                    FullName = s.Customer.Name,
                    BoughtCars = s.Customer.Sales.Count,
                    SpentMoney = s.Car.PartCars.Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToList();

            return XMLConverter.Serialize(customers, rootEl);
        }

        // Problem 17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            const string rootEl = "cars";

            var carsWithParts = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new CarWithPartsOutputDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new PartOfCarOutputDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .ToList();

            return XMLConverter.Serialize(carsWithParts, rootEl);
        }

        // Problem 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            const string rootEl = "suppliers";

            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSupplierOutputDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            return XMLConverter.Serialize(localSuppliers, rootEl);
        }

        // Problem 15. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            const string rootEl = "cars";

            var carsBMW = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarBMWOutputDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            return XMLConverter.Serialize(carsBMW, rootEl);
        }

        // Problem 14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const string rootEl = "cars";

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new CarWithDistanceOutputDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            return XMLConverter.Serialize(cars, rootEl);
        }

        // Problem 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string rootEl = "Sales";

            var salesInput = XMLConverter.Deserializer<SaleInputDto>(inputXml, rootEl);

            var sales = salesInput
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .Select(s => new Sale
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        // Problem 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string rootEl = "Customers";
            InitializeAutoMapper();

            var customersInput = XMLConverter.Deserializer<CustomerInputDto>(inputXml, rootEl);

            var customers = mapper.Map<Customer[]>(customersInput);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        // Problem 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string rootEl = "Cars";

            var carsInput = XMLConverter.Deserializer<CarInputDto>(inputXml, rootEl);

            var allParts = context.Parts.Select(x => x.Id).ToList();

            var cars = carsInput
                .Select(c => new Car
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance,
                    PartCars = c.Parts.Select(p => p.Id)
                        .Distinct()
                        .Intersect(allParts)
                        .Select(p => new PartCar { PartId = p })
                        .ToList()
                })
                .ToList();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        // Problem 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string rootEl = "Parts";

            var partsInput = XMLConverter.Deserializer<PartInputDto>(inputXml, rootEl);

            var parts = partsInput
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            int partsCount = context.SaveChanges();

            return $"Successfully imported {partsCount}";
        }

        // Problem 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string rootEl = "Suppliers";

            var suppliersInput = XMLConverter.Deserializer<SupplierInputDto>(inputXml, rootEl);

            var suppliers = suppliersInput
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            int suppliersCount = context.SaveChanges();

            return $"Successfully imported {suppliersCount}";
        }

        private static void ResetDatabase(CarDealerContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            Console.WriteLine("Db has been deleted successfully!");
            dbContext.Database.EnsureCreated();
            Console.WriteLine("Db has been created successfully!");
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}