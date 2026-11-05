using ApiProject.Models;

namespace ApiProject.Services
{
    public interface IRegisterService
    {
        void addUser(Customers newCustomer);
    }
}