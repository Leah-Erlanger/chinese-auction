using ApiProject.Models;
using ApiProject.Repositiers;

namespace ApiProject.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        //private readonly ILoggerService _logger;
        //private readonly services.Logger.LoggerFactory _loggerFactory;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IEnumerable<Customers> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }
    }
}
