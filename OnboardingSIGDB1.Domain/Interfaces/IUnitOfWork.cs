using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data
{
    public interface IUnitOfWork
    {
        IRepository<Empresa> EmpresaRepository { get; }
        IRepository<Funcionario> FuncionarioRepository { get; }
        IRepository<Cargo> CargoRepository { get; }

        bool Commit();
    }
}
