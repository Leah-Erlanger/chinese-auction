using ApiProject.Models;
using ApiProject.Repositiers;

namespace ApiProject.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        //private readonly ILoggerService _logger;
        //private readonly services.Logger.LoggerFactory _loggerFactory;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public int AddToBasket(int giftId, string userId)
        {
            return _basketRepository.AddToBasket(giftId, userId);

        }

        public async Task<IEnumerable<Baskets>> GetGiftOfUser(string userId)
        {
            return await _basketRepository.GetGiftOfUser(userId);
        }

        public async Task<IEnumerable<Baskets>> delete(int id, string userId)
        {
            return await _basketRepository.delete(id, userId);
        }

        public async Task<IEnumerable<Baskets>> buy(string userId)
        {
            return await _basketRepository.buy(userId);
        }
        public async Task<IEnumerable<Baskets>> a(int num, int giftId, string userId)
        {
            return await _basketRepository.a(num, giftId, userId);
        }
    }
}

