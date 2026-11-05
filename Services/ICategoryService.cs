using ApiProject.Models;

namespace ApiProject.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> addCategory(Category newCategory);
        IEnumerable<Category> GetCategories();
    }
}