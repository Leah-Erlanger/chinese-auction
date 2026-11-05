using ApiProject.Models;
using ApiProject.Repositiers;

namespace ApiProject.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository/*, services.Logger.LoggerFactory loggerFactory*/)
        {
            _categoryRepository = categoryRepository;
            //_loggerFactory = loggerFactory;
            //_logger = _loggerFactory.GetLogger("file");
        }
        public IEnumerable<Category> GetCategories()
        {
            //_logger.Log("hiiiiiiiiiii");
            return _categoryRepository.GetCategories();
        }
        public IEnumerable<Category> addCategory(Category newCategory)
        {
            return _categoryRepository.addCategory(newCategory);
        }
    }
}
