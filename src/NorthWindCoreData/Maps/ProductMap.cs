using System.Data.Entity.ModelConfiguration;
using NorthWindCoreData.Models;

namespace NorthWindCoreData.Maps
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            HasKey(t => t.ProductID);

            // Properties
            Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            Property(t => t.QuantityPerUnit)
                .HasMaxLength(20);

            // Table & Column Mappings
            ToTable("Products");
           Property(t => t.ProductID).HasColumnName("ProductID");
            Property(t => t.ProductName).HasColumnName("ProductName");
            Property(t => t.CategoryID).HasColumnName("CategoryID");
            Property(t => t.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            Property(t => t.UnitsInStock).HasColumnName("UnitsInStock");
            Property(t => t.UnitsOnOrder).HasColumnName("UnitsOnOrder");
            Property(t => t.ReorderLevel).HasColumnName("ReorderLevel");
            Property(t => t.Discontinued).HasColumnName("Discontinued");
        //    Property(t => t.Id).HasColumnName("ProductId");

            // Relationships
            HasOptional(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.CategoryID);
           

        }
    }
}