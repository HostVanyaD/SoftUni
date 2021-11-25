using AutoMapper;
using CarDealer.DTO.Input;
using CarDealer.Models;
using System;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<CustomerInputDto, Customer>()
                .ForMember(t => t.BirthDate, f => f.MapFrom(s => DateTime.Parse(s.BirthDate)));
        }
    }
}
