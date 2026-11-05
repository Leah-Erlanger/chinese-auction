using ApiProject.Models;

namespace ApiProject.Repositiers
{
    public interface ILoginRepository
    {
        Task<IEnumerable<Customers>> GetAllUsers();
    }
}