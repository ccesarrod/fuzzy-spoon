using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NorthWind2.Repositories;
using NorthWindCoreData.Models;

namespace NorthWind2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        // GET: Category
        public ActionResult Index()
        {
            // var context = new ApplicationContext("NorthwindContext");
            var categories = _repository.GetAll();
            return View(categories);
        }

        public ActionResult Products(int categoryId)
        {
            //// var context = new ApplicationContext("NorthwindContext");
            // var categories = new Repository<Category>(context).GetAll().ToList();
            // var category = categories.Single(x => x.CategoryID == categoryId);
            // var products= categories.Single(x => x.CategoryID== categoryId).Products.ToList();
            //// products.ForEach(x => x.ProductName =HttpUtility.JavaScriptStringEncode(x.ProductName));

            //var categories = _repository.GetAll();
            //var category = categories.SingleOrDefault(x => x.CategoryID == categoryId);
            var category = _repository.Find(x => x.CategoryID == categoryId).SingleOrDefault();
            var products = category != null ? category.Products.ToList() : new List<Product>();

            return View("Products", products);
        }
    }
}