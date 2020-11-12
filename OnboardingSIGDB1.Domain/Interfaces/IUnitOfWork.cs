using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;

namespace OnboardingSIGDB1.Data
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
