﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using NorthWindCoreData.Models;

namespace NorthWindCoreData.Maps
{
    public class Order_DetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public Order_DetailMap()
        {
            // Primary Key
            HasKey(t => new { t.OrderID, t.ProductID });

            // Properties
            Property(t => t.OrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.ProductID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            ToTable("Order Details");
            Property(t => t.OrderID).HasColumnName("OrderID");
            Property(t => t.ProductID).HasColumnName("ProductID");
            Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            Property(t => t.Quantity).HasColumnName("Quantity");
            Property(t => t.Discount).HasColumnName("Discount");

            // Relationships
            HasRequired(t => t.Order)
                .WithMany(t => t.Order_Details)
                .HasForeignKey(d => d.OrderID);
           

        }
    }

}
