using OnboardingSIGDB1.Data.Repositories.Interfaces;
using OnboardingSIGDB1.Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace OnboardingSIGDB1.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private DataContext _dataContext { get; }

        public EmpresaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Adicionar(Empresa empresa)
        {
            _dataContext.Empresas.Add(empresa);
            _dataContext.SaveChanges();
        }

        public void Atualizar(Empresa empresa)
        {
            if (_dataContext.Entry(empresa).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _dataContext.Attach(empresa);
                _dataContext.Entry(empresa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _dataContext.Update(empresa);
            }

            _dataContext.SaveChanges();
        }

        public void Deletar(Empresa empresa)
        {
            _dataContext.Empresas.Remove(empresa);
            _dataContext.SaveChanges();
        }

        public bool Existe(int empresaId)
        {
            return _dataContext.Empresas.Any(e => e.Id == empresaId);
        }

        public IEnumerable<Empresa> ObterTodas()
        {
            return _dataContext.Empresas.ToList();
        }

        public Empresa Obter(int empresaId)
        {
            return _dataContext.Empresas.FirstOrDefault(e => e.Id == empresaId);
        }
    }
}
