using System;
using System.ComponentModel.DataAnnotations;

namespace NorthWindCoreData.Models
{
    public class Product: IEntity
    {

        public int ProductID { get; set; }
        [Required]
        [StringLength(10)]
        public string ProductName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public virtual Category Category { get; set; }

        //public int Id { get; set; }
    }
}