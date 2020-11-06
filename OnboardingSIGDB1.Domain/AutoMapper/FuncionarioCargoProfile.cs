using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class FuncionarioCargoProfile : Profile
    {
        public FuncionarioCargoProfile()
        {
            CreateMap<FuncionarioCargo, FuncionarioCargoDTO>().ReverseMap();
        }
    }
}
