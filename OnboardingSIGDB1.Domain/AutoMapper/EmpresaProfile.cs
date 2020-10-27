using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<Empresa, EmpresaDTO>()
                .ForMember(e => e.Cnpj, o => o.MapFrom(f => Convert.ToUInt64(f.Cnpj).ToString(@"00\.000\.000\/0000\-00")));
            CreateMap<EmpresaDTO, Empresa>()
                .ForMember(e => e.Cnpj, o => o.MapFrom(f => Regex.Replace(f.Cnpj, @"[-,.,/]", string.Empty)));
        }
    }
}
