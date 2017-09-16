using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NorthWindData.Models.Mapping
{
    public class CartDetailMap : EntityTypeConfiguration<CartDetail>
    {
        public CartDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CartDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CartId).HasColumnName("CartId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");

            // Relationships
            this.HasOptional(t => t.Cart)
                .WithMany(t => t.CartDetails)
                .HasForeignKey(d => d.CartId);
            this.HasOptional(t => t.Product)
                .WithMany(t => t.CartDetails)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
