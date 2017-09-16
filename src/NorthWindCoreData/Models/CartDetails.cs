﻿using System;

namespace NorthWindCoreData.Models
{
    public class CartDetails : IEntity
    {
        public String CustomerID { get; set; }
        public int Id { get; set; }
       public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
       
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
