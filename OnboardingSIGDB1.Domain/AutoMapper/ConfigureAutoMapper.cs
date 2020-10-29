using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public static class ConfigureAutoMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(m => m.AddProfiles(GetAutoMapperProfiles()));
        }

        private static IEnumerable<Type> GetAutoMapperProfiles()
        {
            return new List<Type> {
                typeof(FuncionarioProfile),
                typeof(EmpresaProfile),
                typeof(CargoProfile),
                typeof(FuncionarioCargoProfile)
            };
        }
    }
}
