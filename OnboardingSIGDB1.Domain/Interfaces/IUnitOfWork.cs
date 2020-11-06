using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;

namespace OnboardingSIGDB1.Data
{
    public interface IUnitOfWork
    {
        IRepository<Empresa> EmpresaRepository { get; }
        IFuncionarioRepository FuncionarioRepository { get; }
        IRepository<Cargo> CargoRepository { get; }
        IRepository<FuncionarioCargo> FuncionarioCargoRepository { get; }

        bool Commit();
    }
}
