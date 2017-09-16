using System;
using System.Collections.Generic;

namespace NorthWindData.Models
{
    public partial class CartDetail
    {
        public int Id { get; set; }
        public Nullable<int> CartId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
