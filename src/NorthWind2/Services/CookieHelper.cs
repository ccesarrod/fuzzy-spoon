using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NorthWind2.Models;
using NorthWindCoreData.Models;

namespace NorthWind2.Services
{
    public static class CookieHelper
    {
        private static string CART = "cart";

        public static List<CartViewModel> GetCartFromCookie(HttpCookieCollection cookies)
        {
            var cookie = cookies.Get(CART);
            var result = cookie == null ? new List<CartViewModel>() : DTDCookieToViewModel(cookie);
            return result;

        }

        private static List<CartViewModel> DTDCookieToViewModel(HttpCookie cookie)
        {
            var cookieValue = HttpUtility.UrlDecode(cookie.Value);
            var cartJson = JsonConvert.DeserializeObject<List<CartViewModel>>(cookieValue);
            return cartJson;
        }


        public static void SaveCartToCookie(HttpCookieCollection cookies, List<CartDetails> cartDetails)
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            if (!cartDetails.Any()) return;
            var cartViewModels = cartDetails.Select(x => new CartViewModel { Id = x.ProductId, Name = x.Product.ProductName, Price = x.Price, Quantity = x.Quantity });
            var serializedViewModels = JsonConvert.SerializeObject(cartViewModels, settings);
            if (cookies.Get(CART) == null)
            {
                cookies.Add(new HttpCookie(CART, serializedViewModels));
            }
            else
            {
                cookies.Get(CART).Value = serializedViewModels;
            }
        }
    }
}