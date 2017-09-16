using NorthWindCoreData;
using NorthWindCoreData.Models;

namespace NorthWind2.Repositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
    }

    public class CategoryRepository: Repository<Category> ,ICategoryRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }

    }
}