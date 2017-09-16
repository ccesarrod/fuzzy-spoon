using System.Collections.Generic;

namespace NorthWind2.Models
{
    public class OrderViewModel
    {
        
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public virtual ICollection<CartViewModel> Items { get; set; }
    }
}