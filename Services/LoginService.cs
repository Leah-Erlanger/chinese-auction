using ApiProject.Models;
using ApiProject.Repositiers;
using Microsoft.AspNetCore.Identity;

namespace ApiProject.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly PasswordHasher<Customers> _passwordHasher;

        public LoginService(ILoginRepository _loginRepository)
        {
            this._loginRepository = _loginRepository;
            _passwordHasher = new PasswordHasher<Customers>();
        }
        public async Task<IEnumerable<Customers>> GetAllUsers()
        {
            return await _loginRepository.GetAllUsers();
        }

        public async Task<Customers?> Login(string userName, string password)
        {
            var user =await _loginRepository.GetAllUsers();
            Customers? customers = user.FirstOrDefault(u => u.NameCustomer == userName);
            if (customers != null)
            {
                var v = _passwordHasher.VerifyHashedPassword(customers, customers.Password, password) == PasswordVerificationResult.Success;
                if (v == false)
                {
                    Console.WriteLine("ggg");
                    return null;
                }
                else
                    return customers;
            }
            else return null;
        }
    }
}
