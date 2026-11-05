using ApiProject.Models;
using TasksApi.Models;

namespace ApiProject.Repositiers
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProjectDbContext _context;

        public CategoryRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Category.ToList();
        }
        public IEnumerable<Category> addCategory(Category newCategory)
        {
            var category = new Category
            {
                Id = newCategory.Id,
                NameCategory = newCategory.NameCategory
            };
            _context.Category.Add(category);
            _context.SaveChanges();
            return GetCategories();

        }
    }
}
