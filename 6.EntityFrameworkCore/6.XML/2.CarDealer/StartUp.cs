using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine("ok");

            //string supplierXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(dbContext, supplierXml));

            //string partXml = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(dbContext, partXml));

            //string carXml = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(dbContext, carXml));

            //string customerXml = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(dbContext, customerXml));

            //string saleXml = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(dbContext, saleXml));

            //Console.WriteLine(GetCarsWithDistance(dbContext));
            //Console.WriteLine(GetCarsFromMakeBmw(dbContext));
            //Console.WriteLine(GetLocalSuppliers(dbContext));
            //Console.WriteLine(GetCarsWithTheirListOfParts(dbContext));
            //Console.WriteLine(GetTotalSalesByCustomer(dbContext));
            Console.WriteLine(GetSalesWithAppliedDiscount(dbContext));

        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[])
                , new XmlRootAttribute("Suppliers"));

            using StringReader stringReader = new StringReader(inputXml);

            ImportSupplierDto[] dtos = (ImportSupplierDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Supplier> suppliers = new HashSet<Supplier>();

            foreach (ImportSupplierDto supplierDto in dtos)
            {
                Supplier s = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = bool.Parse(supplierDto.IsImporter)
                };

                suppliers.Add(s);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportPartDto[])
                , new XmlRootAttribute("Parts"));

            using StringReader stringReader = new StringReader(inputXml);

            ImportPartDto[] dtos = (ImportPartDto[])serializer.Deserialize(stringReader);

            ICollection<Part> parts = new HashSet<Part>();

            foreach (ImportPartDto partDto in dtos)
            {
                Supplier supplier = context
                    .Suppliers
                    .Find(int.Parse(partDto.SupplierId));

                if (supplier == null)
                {
                    continue;
                }

                Part p = new Part()
                {
                    Name = partDto.Name,
                    Price = decimal.Parse(partDto.Price),
                    Quantity = int.Parse(partDto.Quantity),
                    SupplierId = int.Parse(partDto.SupplierId)
                };

                parts.Add(p);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportCarDto[])
                , new XmlRootAttribute("Cars"));

            using StringReader stringReader = new StringReader(inputXml);

            ImportCarDto[] dtos = (ImportCarDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Car> cars = new HashSet<Car>();

            foreach (ImportCarDto carDto in dtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance
                };

                ICollection<PartCar> partCars = new HashSet<PartCar>();

                foreach (int partId in carDto.Parts.Select(p => p.Id).Distinct())
                {
                    Part part = context
                        .Parts
                        .Where(pc => pc.Id == partId)
                        .FirstOrDefault();

                    if (part == null)
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        Part = part
                    };

                    partCars.Add(partCar);
                }

                car.PartCars = partCars;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportCustomerDto[]),
                new XmlRootAttribute("Customers"));

            using StringReader stringReader = new StringReader(inputXml);

            ImportCustomerDto[] dtos = (ImportCustomerDto[])serializer.Deserialize(stringReader);

            ICollection<Customer> customers = new HashSet<Customer>();

            foreach (ImportCustomerDto customerDto in dtos)
            {
                Customer customer = new Customer()
                {
                    Name = customerDto.Name,
                    BirthDate = customerDto.BirthDate,
                    IsYoungDriver = customerDto.IsYoungDriver,
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportSaleDto[]),
                new XmlRootAttribute("Sales"));

            using StringReader stringReader = new StringReader(inputXml);

            ImportSaleDto[] dtos = (ImportSaleDto[])serializer.Deserialize(stringReader);

            ICollection<Sale> sales = new HashSet<Sale>();

            foreach (ImportSaleDto saleDto in dtos)
            {
                Car car = context
                    .Cars
                    .Where(c => c.Id == saleDto.CarId)
                    .FirstOrDefault();

                if (car == null)
                {
                    continue;
                }

                Sale sale = new Sale()
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount,
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer =
                new XmlSerializer(typeof(ExportCarsWithDistanceDto[]),
                new XmlRootAttribute("cars"));


            ExportCarsWithDistanceDto[] carsDtos = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TravelledDistance
                })
                .ToArray();

            serializer.Serialize(stringWriter, carsDtos, xmlSerializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer serializer =
                new XmlSerializer(typeof(ExportCarMakeDto[]),
                new XmlRootAttribute("cars"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportCarMakeDto[] dtos = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarMakeDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TravelledDistance
                })
                .ToArray();

            serializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer serializer =
                new XmlSerializer(typeof(ExportLocalSupplierDto[]),
                new XmlRootAttribute("suppliers"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportLocalSupplierDto[] dtos = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            serializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer serializer =
                new XmlSerializer(typeof(ExportCarWithListDto[]),
                new XmlRootAttribute("cars"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportCarWithListDto[] dtos = context
                .Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportCarWithListDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                    .Select(p => new ExportPartDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .ToArray();

            serializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer serializer =
                new XmlSerializer(typeof(ExportTotalSalesByCustomerDto[]),
                new XmlRootAttribute("customers"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportTotalSalesByCustomerDto[] dtos = context
                .Sales
                .Where(c => c.Customer.Sales.Count > 0)
                .Select(c => new ExportTotalSalesByCustomerDto
                {
                    FullName = c.Customer.Name,
                    BoughtCars = c.Customer.Sales.Count,
                    SpentMoney = c.Car.PartCars.Sum(cc => cc.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            serializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer serializer = 
                new XmlSerializer(typeof(ExportSalesWithDiscountDto[]),
                new XmlRootAttribute("sales"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportSalesWithDiscountDto[] dtos = context
                .Sales
                .Select(s => new ExportSalesWithDiscountDto
                {   
                    Car = new ExportCarAttributeDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TravelledDistance.ToString()
                    },
                    Discount = s.Discount.ToString(),
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(c => c.Part.Price).ToString(),
                    PriceWithDiscount = (s.Car.PartCars.Sum(c => c.Part.Price) - 
                    s.Car.PartCars.Sum(c => c.Part.Price) * s.Discount / 100).ToString()
                })
                .ToArray();

            serializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}

