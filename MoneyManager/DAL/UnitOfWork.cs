using System;
using System.Data.Entity.Infrastructure;

namespace MoneyManager.DAL
{
    public class UnitOfWork : IDisposable
    {
        private MoneyManagerContext context = new MoneyManagerContext();
        private GenericRepository<Record> recordRepository;
        private GenericRepository<Category> categoryRepository;

        public GenericRepository<Record> RecordRepository
        {
            get
            {

                if (this.recordRepository == null)
                {
                    this.recordRepository = new GenericRepository<Record>(context);
                }
                return recordRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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