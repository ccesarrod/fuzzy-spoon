using System;
using System.Data.Entity;
using NorthWindCoreData.Models;

namespace NorthWindCoreData
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;

        private  UnitOfWork _current;


        public UnitOfWork(CustomerOrderContext container)
        {
            Container = container;
            _current = this;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public static Type DefaultContainerType { get; set; }

       

         public DbContext Container { get; private set; }

        public void Commit()
        {
            try
            {
                Container.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IRepository<Product> Product
        {
            get { return new Repository<Product>(_current); }
          
        }

        protected virtual void Dispose(bool disposing)
        {
            if ( disposing  && _disposed)
            {
                if (Container != null)
                    Container.Dispose();
                 
             }

            _disposed = true;
        }


        public IRepository<Order> Order
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<Customer> Customer
        {
            get { return new Repository<Customer>(_current); }
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_current);
        }
    }
}