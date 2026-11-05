using ApiProject.Models;

namespace ApiProject.Services
{
    public interface ILoginService
    {
        Task<IEnumerable<Customers>> GetAllUsers();
         Task<Customers> Login(string userName, string password);
    }
}
