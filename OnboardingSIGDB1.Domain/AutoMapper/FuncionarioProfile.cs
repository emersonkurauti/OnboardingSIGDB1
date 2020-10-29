using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<Funcionario, FuncionarioDTO>()
                .ForMember(f => f.Cpf, o => o.MapFrom(f => Convert.ToUInt64(f.Cpf).ToString(@"000\.000\.000\-00"))); ;
            CreateMap<FuncionarioDTO, Funcionario>()
                .ForMember(f => f.Cpf, o => o.MapFrom(f => Regex.Replace(f.Cpf, @"[-,.]", string.Empty))); ;
        }
    }
}
