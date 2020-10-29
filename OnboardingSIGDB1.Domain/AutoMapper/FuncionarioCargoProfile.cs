using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class FuncionarioCargoProfile : Profile
    {
        public FuncionarioCargoProfile()
        {
            CreateMap<FuncionarioCargo, FuncionarioCargoDTO>();
            CreateMap<FuncionarioCargoDTO, FuncionarioCargo>();
        }
    }
}
