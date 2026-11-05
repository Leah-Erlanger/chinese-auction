using ApiProject.Models;

namespace ApiProject.Services
{
    public interface IBasketService
    {
        int AddToBasket(int giftId, string userId);
        Task<IEnumerable<Baskets>> GetGiftOfUser(string userId);
        Task<IEnumerable<Baskets>> delete(int id, string userId);
        Task<IEnumerable<Baskets>> buy(string userId);
        Task<IEnumerable<Baskets>> a(int num, int giftId, string userId);
    }
}