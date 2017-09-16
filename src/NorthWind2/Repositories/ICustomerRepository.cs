using System.Collections.Generic;
using System.Linq;
using NorthWind2.Models;
using NorthWindCoreData;
using NorthWindCoreData.Models;

namespace NorthWind2.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<CartDetails> SyncShoppingCart(string userEmail, List<CartViewModel> cartUpdates);
        List<CartDetails> GetShoopingCart(string userEmail);
        void DeleteShoppingCart(string userEmail);
        void AddOrder(string userEmail,Order order);
    }

    public class CustomerRepository :Repository<Customer>, ICustomerRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private IRepository<Customer> _customerRepository;
        private IRepository<Product> _productRepository;

        public CustomerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = unitOfWork.Customer;
            _productRepository = unitOfWork.Product;
            
          
        }

        public List<CartDetails> SyncShoppingCart(string userEmail, List<CartViewModel> cartUpdates)
        {


            var customer = _customerRepository.Find(x => x.Email == userEmail).FirstOrDefault();

            bool any = cartUpdates.Any();
            if (!any) if (customer != null) return customer.Cart;
            if (customer != null && customer.Cart.Count == 0)
            {
                customer.Cart = cartUpdates.Select(
                    x => new CartDetails { Price = x.Price, Quantity = x.Quantity, ProductId = x.Id, Product = GetProductById(x.Id) })
                    .ToList();
                _customerRepository.Update(customer);
                _customerRepository.Save();
                //customer = _customerRepository.Find(x => x.Email == userEmail).FirstOrDefault();



            }

            else
            {
                var customerCart = customer != null ? customer.Cart : new List<CartDetails>();
                foreach (var item in cartUpdates)
                {
                    var cartItem = customerCart.SingleOrDefault(x => x.ProductId == item.Id);
                    if (cartItem == null)
                        customerCart.Add(new CartDetails
                        {
                            Price = item.Price,
                            Quantity = item.Quantity,
                            ProductId = item.Id,
                            Product = GetProductById(item.Id)
                        });

                    else

                        if (cartItem.Quantity != item.Quantity) cartItem.Quantity = item.Quantity;
                }
            }


            var xxx = customer.Cart.Select(x => !cartUpdates.Exists(y => y.Id == x.ProductId)).ToList();
            customer.Cart.RemoveAll(x => !cartUpdates.Exists(y => y.Id == x.ProductId));

            _customerRepository.Update(customer);
            return customer.Cart;
        }


        public List<CartDetails> GetShoopingCart(string userEmail)
        {
            var customers = _customerRepository.GetAll();
            var customer = customers.SingleOrDefault(x => x.Email == userEmail);
            return customer != null ? customer.Cart : new List<CartDetails>();
        }

        public void DeleteShoppingCart(string userEmail)
        {
            var customer = _customerRepository.Find(x => x.Email == userEmail).Single();
            customer.Cart.RemoveAll(x => x.ProductId > 0);
            _customerRepository.Update(customer);
            //  _customerRepository.Save();
        }

        public void AddOrder(string userEmail,Order order)
        {
            var customer = _customerRepository.Find(x => x.Email == userEmail).Single();
            customer.Orders.Add(order);
            //customer.Add(order);
            //  var cart = _cartRepository.Find(x => x.CustomerID == customer.CustomerID).ToList();
            var cart = customer.Cart.ToList();
            var cartdetails = _unitOfWork.Repository<CartDetails>();
            
            cart.ForEach(x => cartdetails.Delete(x));
        }
        private Product GetProductById(int id)
        {
            return _productRepository.Find(x => x.ProductID == id).SingleOrDefault();
        }
    }
}
