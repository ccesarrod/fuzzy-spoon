using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using NorthWind2.Models;
using NorthWind2.Services;
using NorthWindCoreData;
using NorthWindCoreData.Models;

namespace NorthWind2.Controllers
{
     [System.Web.Http.Route("api/Order")]
    public class OrderController : ApiController
    {
        public OrderController(IOrderMapper mapper, IRepository<Order> repository)
        {
        }

        // GET: api/Order
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET: api/Order/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
      
        public void Post([FromBody]OrderViewModel orderViewModel)
        {
            var x = orderViewModel;
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
