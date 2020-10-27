using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<Funcionario, FuncionarioDTO>();
            CreateMap<FuncionarioDTO, Funcionario>();
        }
    }
}
