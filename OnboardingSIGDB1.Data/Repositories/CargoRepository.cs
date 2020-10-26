using OnboardingSIGDB1.Data.Repositories.Interfaces;
using OnboardingSIGDB1.Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace OnboardingSIGDB1.Data.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private DataContext _dataContext { get; }

        public CargoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Adicionar(Cargo cargo)
        {
            _dataContext.Cargos.Add(cargo);
            _dataContext.SaveChanges();
        }

        public void Atualizar(Cargo cargo)
        {
            if (_dataContext.Entry(cargo).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _dataContext.Attach(cargo);
                _dataContext.Entry(cargo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _dataContext.Update(cargo);
            }

            _dataContext.SaveChanges();
        }

        public void Deletar(Cargo cargo)
        {
            _dataContext.Cargos.Remove(cargo);
            _dataContext.SaveChanges();
        }

        public bool Existe(int cargoId)
        {
            return _dataContext.Cargos.Any(c => c.Id == cargoId);
        }

        public IEnumerable<Cargo> ObterTodos()
        {
            return _dataContext.Cargos.ToList();
        }

        public Cargo Obter(int cargoId)
        {
            return _dataContext.Cargos.FirstOrDefault(c => c.Id == cargoId);
        }
    }
}
