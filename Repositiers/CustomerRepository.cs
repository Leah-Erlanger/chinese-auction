using ApiProject.Models;
using TasksApi.Models;

namespace ApiProject.Repositiers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ProjectDbContext _context;
        public CustomerRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Customers> GetCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
