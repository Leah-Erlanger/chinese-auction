using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using TasksApi.Models;

namespace ApiProject.Repositiers
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ProjectDbContext _context;

        public LoginRepository(ProjectDbContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Customers>> GetAllUsers()
        {
            return await _context.Customers.ToListAsync();

        }

    }
}
