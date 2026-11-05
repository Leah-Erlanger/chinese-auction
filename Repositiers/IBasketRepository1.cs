using ApiProject.Models;

namespace ApiProject.Repositiers
{
    public interface IBasketRepository
    {
        int AddToBasket(int GiftId, string userId);
        int getNumGift(int GiftId, string userId);
        Task<IEnumerable<Baskets>> GetGiftOfUser(string userId);
        Task<IEnumerable<Baskets>> delete(int id, string userId);
        Task<IEnumerable<Baskets>> buy(string userId);
        Task<IEnumerable<Baskets>> a(int num, int giftId, string userId);
    }
}