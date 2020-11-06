using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<Cargo, CargoDTO>().ReverseMap();
        }
    }
}
