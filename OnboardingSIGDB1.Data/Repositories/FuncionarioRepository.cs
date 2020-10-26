using OnboardingSIGDB1.Data.Repositories.Interfaces;
using OnboardingSIGDB1.Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace OnboardingSIGDB1.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private DataContext _dataContext { get; }

        public FuncionarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Adicionar(Funcionario funcionario)
        {
            _dataContext.Funcionarios.Add(funcionario);
            _dataContext.SaveChanges();
        }

        public void Atualizar(Funcionario funcionario)
        {
            if (_dataContext.Entry(funcionario).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _dataContext.Attach(funcionario);
                _dataContext.Entry(funcionario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _dataContext.Update(funcionario);
            }

            _dataContext.SaveChanges();
        }

        public void Deletar(Funcionario funcionario)
        {
            _dataContext.Funcionarios.Remove(funcionario);
            _dataContext.SaveChanges();
        }

        public bool Existe(int funcionarioId)
        {
            return _dataContext.Funcionarios.Any(f => f.Id == funcionarioId);
        }

        public Funcionario Obter(int funcionarioId)
        {
            return _dataContext.Funcionarios.FirstOrDefault(f => f.Id == funcionarioId);
        }

        public IEnumerable<Funcionario> ObterTodos()
        {
            return _dataContext.Funcionarios.ToList();
        }
    }
}
