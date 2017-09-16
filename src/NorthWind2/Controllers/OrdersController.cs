using System.Linq;
using System.Net;
using System.Web.Mvc;
using NorthWind2.Models;
using NorthWind2.Repositories;
using NorthWind2.Services;

namespace NorthWind2.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public OrdersController(IOrderMapper mapper,  ICustomerRepository customerRepository )
        {
          
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpStatusCodeResult Save(OrderViewModel orderViewModel)
        {
            var userEmail = User.Identity.Name;
            var customer = _customerRepository.Find(x => x.Email == userEmail).Single();
            if (customer != null)
            {
               
                var order = _mapper.Map(orderViewModel);
                _customerRepository.AddOrder(userEmail, order);
                ////  order.Customer = customer;
                ////  order.CustomerID = customer.CustomerID;
                //  customer.Orders.Add(order);
                //  //customer.Add(order);
                ////  var cart = _cartRepository.Find(x => x.CustomerID == customer.CustomerID).ToList();
                //  var cart = customer.Cart.ToList();
                //  cart.ForEach(x => _cartRepository.Delete(x));

            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}