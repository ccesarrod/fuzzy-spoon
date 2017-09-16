using System.Collections.Generic;

namespace NorthWindCoreData.Models
{
    public class ShoppingCart : IEntity
    {
        public ShoppingCart()
        {
            CartDetail = new List<CartDetails>();
        }
  
        public int CartId    {  get;set; }
        
        public ICollection<CartDetails> CartDetail { get; set; }
       
    
        public virtual  Customer Customer { get; set; }
        
    }
}
