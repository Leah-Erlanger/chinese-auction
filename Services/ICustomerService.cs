using ApiProject.Models;

namespace ApiProject.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customers> GetCustomers();
    }
}