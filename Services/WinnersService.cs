using API_PROJECT.Repositiers;
using ApiProject.Models;
using ApiProject.Repositiers;
using Microsoft.AspNetCore.Identity;

namespace ApiProject.Services
{
    public class WinnersService : IWinnersService
    {
        private readonly IWinnersRepository _winnersRepository;

        //private readonly ILoggerService _logger;
        //private readonly services.Logger.LoggerFactory _loggerFactory;

        public WinnersService(IWinnersRepository winnersRepository)
        {
            _winnersRepository = winnersRepository;
        }
        public async Task<Customers> AddListOfWinner(int giftId)
        {
            return await _winnersRepository.AddListOfWinner(giftId);
        }

        public async Task<IEnumerable<WinnerMask>> GetWinnerMask()
        {
            return await _winnersRepository.GetWinnerMask();
        }
    }
}
