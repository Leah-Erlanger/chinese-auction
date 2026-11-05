using ApiProject.Models;

namespace ApiProject.Repositiers
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetCustomers();
    }
}