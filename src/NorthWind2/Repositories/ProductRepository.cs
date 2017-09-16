using NorthWindCoreData;
using NorthWindCoreData.Models;

namespace NorthWind2.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        
    }

    public class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

       
    }
}