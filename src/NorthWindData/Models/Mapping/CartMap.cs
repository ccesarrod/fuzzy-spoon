using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NorthWindData.Models.Mapping
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.CustomerID });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CustomerID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("Carts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");

            // Relationships
            this.HasOptional(t => t.Product)
                .WithMany(t => t.Carts)
                .HasForeignKey(d => d.ProductId);
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Carts)
                .HasForeignKey(d => d.CustomerID);

        }
    }
}
