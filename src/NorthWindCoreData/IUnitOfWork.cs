using System;
using System.Data.Entity;
using NorthWindCoreData.Models;

namespace NorthWindCoreData
{
    public interface IUnitOfWork : IDisposable 
    {
       
        DbContext Container { get; }
        void Commit();
        IRepository<Product> Product { get; }
        IRepository<Order> Order { get; }
        IRepository<Customer> Customer { get; }
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

    }
}