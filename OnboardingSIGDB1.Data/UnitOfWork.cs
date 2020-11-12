using System;

namespace OnboardingSIGDB1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext = null;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Commit()
        {
            return _dataContext.SaveChanges() != 0;
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
