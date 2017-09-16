using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NorthWind2.Models;
using NorthWindCoreData;
using NorthWindCoreData.Models;

namespace NorthWind2.Services
{
    //public class CartService : ICartService
    //{
    //    private readonly IRepository<Customer> _customerRepository;
    //    private readonly IRepository<Product> _productRepository;
    //    private string CART = "cart";

    //    public CartService(IRepository<Customer> customerRepository)
    //    {
    //        _customerRepository = customerRepository;
    //        //_productRepository = productRepository;
    //    }

    //    public List<CartDetails> SyncShoppingCart(string userEmail, List<CartViewModel> cartUpdates)
    //    {
          

    //        var customer = _customerRepository.Find(x => x.Email == userEmail).FirstOrDefault();

    //        bool any = cartUpdates.Any();
    //        if (!any) if (customer != null) return customer.Cart;
    //        if (customer != null && customer.Cart.Count == 0)
    //        {
    //            customer.Cart = cartUpdates.Select(
    //                x => new CartDetails { Price = x.Price, Quantity = x.Quantity, ProductId = x.Id,Product = GetProductById(x.Id)})
    //                .ToList();
    //            _customerRepository.Update(customer);
    //            _customerRepository.Save();
    //            //customer = _customerRepository.Find(x => x.Email == userEmail).FirstOrDefault();
               


    //        }

    //        else
    //        {
    //            var customerCart = customer != null ? customer.Cart : new List<CartDetails>();
    //            foreach (var item in cartUpdates)
    //            {
    //                var cartItem = customerCart.SingleOrDefault(x => x.ProductId == item.Id);
    //                if (cartItem == null)
    //                    customerCart.Add(new CartDetails
    //                    {
    //                        Price = item.Price,
    //                        Quantity = item.Quantity,
    //                        ProductId = item.Id,
    //                        Product = GetProductById(item.Id)
    //                    });

    //                else

    //                    if (cartItem.Quantity != item.Quantity) cartItem.Quantity = item.Quantity;
    //            }
    //        }


    //        var xxx = customer.Cart.Select(x => !cartUpdates.Exists(y => y.Id == x.ProductId)).ToList();
    //        customer.Cart.RemoveAll(x => !cartUpdates.Exists(y => y.Id == x.ProductId));

    //        _customerRepository.Update(customer);
    //        return customer.Cart;
    //    }

    //    private Product GetProductById(int id)
    //    {
    //        return _productRepository.Find(x => x.ProductID == id).SingleOrDefault();
    //    }


    //    public List<CartDetails> GetShoopingCart(string userEmail)
    //    {
    //        var customers = _customerRepository.GetAll();
    //        var customer = customers.SingleOrDefault(x => x.Email == userEmail);
    //        return customer != null ? customer.Cart : new List<CartDetails>();
    //    }

    //    public void DeleteCustomerShoppingCart(string userEmail)
    //    {
    //        var customer = _customerRepository.Find(x => x.Email == userEmail).Single();
    //        customer.Cart.RemoveAll(x => x.ProductId > 0);
    //        _customerRepository.Update(customer);
    //        //  _customerRepository.Save();
    //    }

    //    public List<CartViewModel> GetCartFromCookie(HttpCookieCollection cookies)
    //    {
    //        var cookie = cookies.Get(CART);
    //        var result = cookie == null ? new List<CartViewModel>() : DTDCookieToViewModel(cookie);
    //        return result;

    //    }



    //    private List<CartViewModel> DTDCookieToViewModel(HttpCookie cookie)
    //    {
    //        var cookieValue = HttpUtility.UrlDecode(cookie.Value);
    //        var cartJson = JsonConvert.DeserializeObject<List<CartViewModel>>(cookieValue);
    //        return cartJson;
    //    }


    //    public void SaveCartToCookie(HttpCookieCollection cookies, List<CartDetails> cartDetails)
    //    {
    //        var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
    //        if ( !cartDetails.Any() ) return;
    //        var cartViewModels = cartDetails.Select(x => new CartViewModel { Id = x.ProductId, Name = x.Product.ProductName, Price = x.Price, Quantity = x.Quantity });
    //        var serializedViewModels = JsonConvert.SerializeObject(cartViewModels, settings);
    //        if (cookies.Get(CART) == null)
    //        {
    //            cookies.Add(new HttpCookie(CART, serializedViewModels));
    //        }
    //        else
    //        {
    //            cookies.Get(CART).Value = serializedViewModels;
    //        }
    //    }
    //}
}