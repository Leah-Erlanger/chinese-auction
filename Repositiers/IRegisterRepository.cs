using ApiProject.Models;

namespace ApiProject.Repositiers
{
    public interface IRegisterRepository
    {
        void addUser(Customers newCustomer);
    }
}