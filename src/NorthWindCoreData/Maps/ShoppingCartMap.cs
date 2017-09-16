using System.Data.Entity.ModelConfiguration;
using NorthWindCoreData.Models;

namespace NorthWindCoreData.Maps
{
    public class ShoppingCartMap : EntityTypeConfiguration<ShoppingCart>
    {
        public ShoppingCartMap()
        {
            
                // Primary Key
                HasKey(t => t.CartId);
        

                // Table & Column Mappings

                ToTable("Cart");
                Property(t => t.CartId).HasColumnName("CartId");
              

        }
    }
}
