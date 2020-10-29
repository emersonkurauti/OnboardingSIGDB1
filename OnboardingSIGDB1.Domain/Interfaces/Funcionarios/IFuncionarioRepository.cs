using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces.Funcionarios
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        IList<FuncionarioConsultaDTO> GetAllFuncionarios();
    }
}
