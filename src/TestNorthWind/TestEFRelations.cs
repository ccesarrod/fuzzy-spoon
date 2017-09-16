using System.Collections.Generic;
using System.Linq;
using NorthWindCoreData;
using NorthWindCoreData.Models;
using NUnit.Framework;

namespace TestNorthWind
{
    [TestFixture]
    [Category("Data")]

    public class TestEFRelations : BaseContainerTest
    {
        private IRepository<Customer> _repository;

        [SetUp]
        public void Init()
        {
            _repository = Container.GetInstance<IRepository<Customer>>();
        }
        [Test]
        public void it_should_get_Customers()
        {
            // var context = new ApplicationContext("Northwind");
            //   var cart1 = new Repository<ShoppingCart>(context).GetAll().ToList();

            var customers = _repository.GetAll().ToList();

            Assert.IsInstanceOf<IEnumerable<Customer>>(customers);
        }

        [Test]
        public void it_should_get_shopping_cart_by_user()
        {

            var customers = _repository.GetAll().ToArray();
            var customer = !customers.Any() ? null : customers.ElementAt(0);
            var cart = customer.Cart;
            Assert.IsInstanceOf<ICollection<CartDetails>>(cart);
        }

        [Test]
        public void it_should_get_products_by_category_id()
        {

            var categories = Container.GetInstance<IRepository<Category>>().GetAll().ToList();

            var products = categories.Single(x => x.CategoryID == 4).Products.ToList();

            Assert.GreaterOrEqual(products.Count(), 0);
        }

        [Test]
        public void it_should_not_contain_forbidden_chars()
        {

            var categories = Container.GetInstance<IRepository<Category>>().GetAll().ToList();

            var products = categories.Single(x => x.CategoryID == 2).Products.ToList();
            products.ForEach(x => x.ProductName = x.ProductName.Replace("'", @"\'"));
            //Console.WriteLine(HttpUtility);
            Assert.AreEqual(@"Chef Anton\'s Cajun Seasoning", products[1].ProductName);
        }

        [Test]
        public void it_should_update_cart_hierarchy()
        {
            var customers = _repository.GetAll().ToList();
            var customer = customers[0];
            var cart = customer.Cart;
            if ( !cart.Exists(x=>x.ProductId == 4))
                cart.Add(new CartDetails {Price = 10,ProductId = 4,Quantity = 10});
            else
            {
                cart.First(x => x.ProductId == 4).Quantity += 10;
            }
            _repository.Save();

            customers = _repository.GetAll().ToList();
            customer = customers[0];
            cart = customer.Cart;
            customer.Cart.First(x => x.ProductId == 4 ).Quantity = 0;
            _repository.Save();

            Assert.AreEqual(0, customer.Cart.Single(x => x.ProductId == 4).Quantity);
            customer.Cart.RemoveRange(0,1);
            _repository.Save();
            Assert.AreEqual(0, customer.Cart.Count());
        }
    }
}
