using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<InputSuppliersDto, Supplier>();

            CreateMap<InputPartsDto, Part>();

            CreateMap<InputCustomerDto, Customer>();

            CreateMap<InputCarsDto, Car>();

            CreateMap<InputSalesDto, Sale>();
        }
    }
}
