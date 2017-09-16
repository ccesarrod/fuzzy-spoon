using System.Collections.Generic;

namespace NorthWindCoreData.Models
{
    public partial class Category : IEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public virtual ICollection<Product> Products { get; set; }
       // public int Id {get; set;}
    }
}