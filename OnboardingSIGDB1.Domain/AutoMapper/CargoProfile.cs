using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<Cargo, CargoDTO>();
            CreateMap<CargoDTO, Cargo>();
        }
    }
}
