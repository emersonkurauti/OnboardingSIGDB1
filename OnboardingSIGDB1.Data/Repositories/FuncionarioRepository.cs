using AutoMapper.QueryableExtensions;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnboardingSIGDB1.Data.Repositories
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(DataContext dataContext) : base(dataContext) { }

        public IList<FuncionarioConsultaDTO> GetAllFuncionarios()
        {
            var result = _dbSet.ProjectTo<FuncionarioConsultaDTO>().ToList();
            return result;
        }
    }
}
