using System.Linq;
using System.Web.Mvc;
using NorthWind2.Repositories;
using NorthWindCoreData;
using NorthWindCoreData.Models;

namespace NorthWind2.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product> _product;
        private readonly CategoryRepository _categoryRepository;
        private readonly IRepository<Product> _productRepository;

        public ProductController(IUnitOfWork unitOfWork,CategoryRepository categoryRepository)
        {

            _product = unitOfWork.Product;
            _categoryRepository = categoryRepository;
            //_productRepository = productRepository;
        }

        // GET: Product
        public ActionResult Index()
        {

           var test_one_db = _categoryRepository.GetAll().ToList();
            var products = _product.GetAll().ToList();
           
            return View(products);
        }

        public ActionResult ReadAllProducts()
        {
            return Content("This is atest");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            // var product = _product.GetAll().ToList().SingleOrDefault(x => x.ProductID == id);

            var product = _product.Find(x => x.ProductID == id).Single();

            return View("EditProduct", product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            _product.Update(product);
           // _product.Save();
            return View("EditProduct", product);

        }
    }
}