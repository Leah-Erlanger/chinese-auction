using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using TasksApi.Models;
namespace ApiProject.Repositiers
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly ProjectDbContext _context;
        public RegisterRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public void addUser(Customers newCustomer)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();

        }
    }
}
