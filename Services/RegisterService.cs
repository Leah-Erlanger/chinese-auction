using ApiProject.Models;
using ApiProject.Repositiers;
using Microsoft.AspNetCore.Identity;

namespace ApiProject.Services
{
    public class RegisterService : IRegisterService
    {
        public readonly IRegisterRepository _registerRepository;
        private readonly PasswordHasher<Customers> _passwordHasher;

        public RegisterService(IRegisterRepository registerRepository/*, services.Logger.LoggerFactory loggerFactory*/)
        {
            _registerRepository = registerRepository;
            _passwordHasher = new PasswordHasher<Customers>();
        }
        public void addUser(Customers newCustomer)
        {
            newCustomer.Password = _passwordHasher.HashPassword(newCustomer,newCustomer.Password);
            newCustomer.IsManager = false;
            _registerRepository.addUser(newCustomer);
        }
    }
}
