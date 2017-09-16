using System.Linq;
using NorthWind2.Repositories;
using NorthWindCoreData.Models;
using NUnit.Framework;

namespace TestNorthWind
{
    [TestFixture]
    [Category("Data")]
    public class TestUnitOfWork:BaseContainerTest
    {

        [Test]
        public void it_should_update_product()
        {
            Product product = null;
            var repository = Container.GetInstance<ProductRepository>();
            
                var products = repository.GetAll();
                product = products.First();
            
            var quantity = product.UnitsInStock;

            product.UnitsInStock++;
            var repository1 = Container.TryGetInstance<ProductRepository>();
            
                repository1.Update(product);
                Assert.Greater(product.UnitsInStock, quantity);
            

        }

        

        
    }
}
