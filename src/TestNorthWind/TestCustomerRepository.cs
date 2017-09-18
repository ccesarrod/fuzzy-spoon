using System.Collections.Generic;
using System.Linq;
using NorthWind2.Models;
using NorthWind2.Repositories;
using NorthWind2.Services;
using NorthWindCoreData;
using NorthWindCoreData.Models;
using NUnit.Framework;

namespace TestNorthWind
{
    [TestFixture]
    [Category("Data")]
    public class TestCustomerRepository : BaseContainerTest
    {
        private const string CustomerEmail = "AnaT@MyTrujillo.cc";
        private ICustomerRepository _service;
        private List<CartViewModel> _clientCart;
        private CartViewModel _viewModel;

        [SetUp]
        public void Init()
        {
            _service = Container.GetInstance<ICustomerRepository>();
           
            _viewModel = new CartViewModel { Price = 10, Id = 4, Quantity = 2 };
            _clientCart = new List<CartViewModel> { _viewModel };
        }


        [TearDown]
        public void End()
        {
            _service = null;
        }


        [Test]
        public void it_should_add_customer()
        {
            _service.Add(new Customer { Email = "test1@gmail.com", ContactName = "test1@gmail.com", Password = "model.Password" , CustomerID="test1", CompanyName="xcnvd"});
            var result = _service.Find(x => x.Email == "test@gmail.com").ToList();
            Assert.AreEqual(result.Count, 1);
        }
        [Test]

        public void it_should_sync_shopping_cart()
        {
            var currentCart = _service.GetShoopingCart(CustomerEmail);
            
            var quantity = currentCart.Single(x => x.ProductId == _viewModel.Id).Quantity;

            var result = _service.SyncShoppingCart(CustomerEmail, _clientCart);

            var updatedQuantity = result.Single(x => x.ProductId == _viewModel.Id).Quantity;
            Assert.Greater(updatedQuantity,quantity);
        }

        [Test]
        public void it_should_empty_cart()
        {
            var cart =  _service.SyncShoppingCart(CustomerEmail, _clientCart);
            _service.DeleteShoppingCart(CustomerEmail);

            Assert.AreEqual(cart.Count(), 0);
        }

        [Test]
        public void it_should_update_disconected_cart()
        {
            Customer customer = null;
            CartDetails item = null;
            using (var context = new UnitOfWork(new CustomerOrderContext("Northwind")))
            {
                var repository = new Repository<Customer>(context);
                customer = repository.GetAll().Single(x => x.Email == CustomerEmail);
                item = customer.Cart.First(x => x.ProductId == _viewModel.Id);
            }

            
            var quantity = item.Quantity;
            item.Quantity += 1;

            using (var context = new UnitOfWork(new CustomerOrderContext("Northwind")))
            {
                var repository = new Repository<Customer>(context);
                repository.Update(customer);
               // customer = repository.GetAll().Single(x => x.Email == CustomerEmail);
                repository.Save();
              
            }

           
            Assert.Greater(item.Quantity, quantity);
        }

        [Test]
        public void it_shoud_build_order_repository()
        {
            var orderRepository = Container.GetInstance<IRepository<Order>>();
        }

    }
}
