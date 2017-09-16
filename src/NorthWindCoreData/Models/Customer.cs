﻿using System.Collections.Generic;

namespace NorthWindCoreData.Models
{
    public partial class Customer:IEntity
    {
        public Customer()
        {
           Cart=new List<CartDetails>();
           
        }
       
        public string CustomerID { get; set; }
      
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        
  
        public virtual List<CartDetails> Cart { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
       

       
    }
}
