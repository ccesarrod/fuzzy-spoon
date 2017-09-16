using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using NorthWindCoreData.Maps;

namespace NorthWindCoreData
{
    public class CustomerOrderContext : DbContext, IDbContext
    {
        public CustomerOrderContext()
        {
           
        }

        public CustomerOrderContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            
        }
      
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
           // modelBuilder.Configurations.InsertOrUpdate(new ShoppingCartMap());
            modelBuilder.Configurations.Add(new CartDetailsMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new Order_DetailMap());
          
        }

        public new void Dispose()
        {
            
            base.Dispose();
        }

        // public DbSet<Product> Products { get; set; }

       // public System.Data.Entity.DbSet<Category> Categories { get; set; }
    }

  
}