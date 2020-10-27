using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<EmpresaDTO, Empresa>();
        }
    }
}
