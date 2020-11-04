using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<Funcionario, FuncionarioDTO>()
                .ForMember(f => f.Cpf, o => o.MapFrom(f => Convert.ToUInt64(f.Cpf).ToString(@"000\.000\.000\-00")));
            CreateMap<FuncionarioDTO, Funcionario>()
                .ForMember(f => f.Cpf, o => o.MapFrom(f => Regex.Replace(f.Cpf, @"[-,.]", string.Empty)));
            CreateMap<Funcionario, FuncionarioConsultaDTO>()
                .ForMember(dest => dest.CargoId, opt => {
                    opt.PreCondition(src => src.Count() > 0);
                    opt.MapFrom(f => f.FuncionarioCargo.OrderByDescending(x => x.DataVinculo).FirstOrDefault().CargoId);
                })
                .ForMember(dest => dest.CargoDescricao, opt => {
                    opt.PreCondition(src => src.Count() > 0);
                    opt.MapFrom(f => f.FuncionarioCargo.OrderByDescending(x => x.DataVinculo).FirstOrDefault().Cargo.Descricao);
                })
                .ForMember(dest => dest.DataVinculo, opt => {
                    opt.PreCondition(src => src.Count() > 0);
                    opt.MapFrom(f => f.FuncionarioCargo.OrderByDescending(x => x.DataVinculo).FirstOrDefault().DataVinculo);
                })
                .ForMember(dest => dest.EmpresaNome, opt => opt.MapFrom(f => f.Empresa.Nome))
                .ForMember(f => f.Cpf, o => o.MapFrom(f => Convert.ToUInt64(f.Cpf).ToString(@"000\.000\.000\-00")));
        }
    }
}
