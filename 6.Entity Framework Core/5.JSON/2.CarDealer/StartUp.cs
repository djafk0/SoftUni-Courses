using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string suppliersJsonAsString = File.ReadAllText("../../../Datasets/suppliers.json");
            //string partsJsonAsString = File.ReadAllText("../../../Datasets/parts.json");
            //string carsJsonAsString = File.ReadAllText("../../../Datasets/cars.json");
            //string customersJsonAsString = File.ReadAllText("../../../Datasets/customers.json");
            //string salesJsonAsString = File.ReadAllText("../../../Datasets/sales.json");


            //Console.WriteLine(ImportSuppliers(context, suppliersJsonAsString));
            //Console.WriteLine(ImportParts(context, partsJsonAsString));
            //Console.WriteLine(ImportCars(context, carsJsonAsString));
            //Console.WriteLine(ImportCustomers(context, customersJsonAsString));
            //Console.WriteLine(ImportSales(context, salesJsonAsString));
            //Console.WriteLine(GetOrderedCustomers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            //Console.WriteLine(GetTotalSalesByCustomer(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IEnumerable<InputSuppliersDto> suppliers = JsonConvert.DeserializeObject<IEnumerable<InputSuppliersDto>>(inputJson);

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(mapperConfiguration);

            IEnumerable<Supplier> mappedSuppliers = mapper.Map<IEnumerable<Supplier>>(suppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var ids = context
                .Suppliers
                .Select(x => x.Id)
                .ToArray();

            IEnumerable<InputPartsDto> parts = JsonConvert.DeserializeObject<IEnumerable<InputPartsDto>>(inputJson)
                .Where(x => ids.Contains(x.SupplierId));

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(mapperConfiguration);

            IEnumerable<Part> mappedParts = mapper.Map<IEnumerable<Part>>(parts);

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            MapperConfiguration config = new MapperConfiguration(cnfg =>
            {
                cnfg.AddProfile<CarDealerProfile>();
            });

            IMapper mapper = config.CreateMapper();

            var carsData = JsonConvert.DeserializeObject<IEnumerable<InputCarsDto>>(inputJson);

            List<Car> carsToImport = new List<Car>();

            HashSet<int> existingParstsIds = context.Parts
                 .Select(p => p.Id)
                 .ToHashSet();

            foreach (var car in carsData)
            {
                Car currentCar = mapper.Map<Car>(car);

                foreach (var partId in car.PartsId.Distinct())
                {
                    if (existingParstsIds.Contains(partId))
                    {
                        PartCar currentPart = new PartCar()
                        {
                            PartId = partId,
                            Car = currentCar
                        };

                        currentCar.PartCars.Add(currentPart);
                    }
                }

                carsToImport.Add(currentCar);
            }

            context.Cars.AddRange(carsToImport);
            context.SaveChanges();


            return $"Successfully imported {carsToImport.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IEnumerable<InputCustomerDto> customers = JsonConvert.DeserializeObject<IEnumerable<InputCustomerDto>>(inputJson);

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(mapperConfiguration);

            IEnumerable<Customer> mappedCustomers = mapper.Map<IEnumerable<Customer>>(customers);

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IEnumerable<InputSalesDto> sales = JsonConvert.DeserializeObject<IEnumerable<InputSalesDto>>(inputJson);

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(mapperConfiguration);

            IEnumerable<Sale> mappedSales = mapper.Map<IEnumerable<Sale>>(sales);

            context.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var result = context
                .Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToArray();

            return JsonConvert.SerializeObject(result);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var result = context
                .Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            return JsonConvert.SerializeObject(result);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var result = context
                .Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToArray();

            return JsonConvert.SerializeObject(result);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var result = context
                .Cars
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance,
                    },
                    parts = x.PartCars
                        .Select(q => new
                        {
                            Name = q.Part.Name,
                            Price = q.Part.Price.ToString("F2")
                        })
                        .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var result = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var result = context
                .Sales
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
                    price = (s.Car.PartCars.Sum(pc => pc.Part.Price)).ToString("F2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) * ((100 - s.Discount) / 100)).ToString("F2")
                })
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
    }
}