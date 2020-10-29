using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using System;
using OnboardingSIGDB1.Data.Repositories;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext = null;
        private Repository<Empresa> empresaRepository = null;
        private FuncionarioRepository funcionarioRepository = null;
        private Repository<Cargo> cargoRepository = null;
        private Repository<FuncionarioCargo> funcionarioCargoRepository = null;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Commit()
        {
            return _dataContext.SaveChanges() != 0;
        }

        public IRepository<Empresa> EmpresaRepository
        {
            get
            {
                if (empresaRepository == null)
                    empresaRepository = new Repository<Empresa>(_dataContext);

                return empresaRepository;
            }
        }

        public IFuncionarioRepository FuncionarioRepository
        {
            get
            {
                if (funcionarioRepository == null)
                    funcionarioRepository = new FuncionarioRepository(_dataContext);

                return funcionarioRepository;
            }
        }

        public IRepository<Cargo> CargoRepository
        {
            get
            {
                if (cargoRepository == null)
                    cargoRepository = new Repository<Cargo>(_dataContext);

                return cargoRepository;
            }
        }

        public IRepository<FuncionarioCargo> FuncionarioCargoRepository
        {
            get
            {
                if (funcionarioCargoRepository == null)
                    funcionarioCargoRepository = new Repository<FuncionarioCargo>(_dataContext);

                return funcionarioCargoRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
