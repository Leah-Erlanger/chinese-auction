using ApiProject.Models;

namespace ApiProject.Repositiers
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> addCategory(Category newCategory);
        IEnumerable<Category> GetCategories();
    }
}