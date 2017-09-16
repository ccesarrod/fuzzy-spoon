using System.Data.Entity.ModelConfiguration;
using NorthWindCoreData.Models;

namespace NorthWindCoreData.Maps
{
    public class CartDetailsMap : EntityTypeConfiguration<CartDetails>
    {

        public CartDetailsMap()
        {
            // Primary Key
            // Primary Key
            this.HasKey(t => t.Id);


            // Table & Column Mappings
            ToTable("Carts");
           
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ProductId).HasColumnName("ProductId");
            Property(t => t.Quantity).HasColumnName("Quantity");
            Property(t => t.Price).HasColumnName("UnitPrice");

            HasOptional(t => t.Customer)
            .WithMany(t => t.Cart)
            .HasForeignKey(t => t.CustomerID);

            
        }


    }
}
