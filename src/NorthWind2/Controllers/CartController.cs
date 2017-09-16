using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using NorthWind2.Models;
using NorthWind2.Repositories;
using NorthWind2.Services;
using NorthWindCoreData;
using NorthWindCoreData.Models;

namespace NorthWind2.Controllers
{
    public class CartController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
       


        public CartController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        
           
        }

        // GET: ShoppingCart
        public ActionResult Index()
        {
            
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    var cart = GetCartFromCookie();
            //    Customer customer = GetAutenticatedCustomer();
            //    _customerRepository.SyncShoppingCart(customer.Email, GetCartFromCookie());
            //}

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Save(List<CartViewModel> cartView)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var customer = GetAutenticatedCustomer();
                _customerRepository.SyncShoppingCart(customer.Email, cartView);
            }
            return View("Index");
        }

        public ActionResult ThankYou()
        {

            return View();
        }
        //private List<CartViewModel> GetCartFromCookie()
        //{
        //    var cookie = HttpContext.Request.Cookies.Get("cart");
        //    var result = cookie == null ? new List<CartViewModel>() : DTDCookieToViewModel(cookie);
        //    return result;

        //}

        private List<CartViewModel> DtdCookieToViewModel(HttpCookie cookie)
        {
            var cookieValue = HttpUtility.UrlDecode(cookie.Value);
            var cartViewModels = JsonConvert.DeserializeObject<List<CartViewModel>>(cookieValue);
            
            return cartViewModels;
        }

        private Customer GetAutenticatedCustomer()
        {

            return User.Identity.IsAuthenticated ? GetCustomerByEmail() : new Customer();

        }

        private Customer GetCustomerByEmail()
        {
            var user = HttpContext.User.Identity.Name;
            var customers = _customerRepository.GetAll();
            return customers.First(x => x.Email == user);
        }

        
    }
}