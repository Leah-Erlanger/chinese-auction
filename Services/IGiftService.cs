using ApiProject.Models;

namespace ApiProject.Services
{
    public interface IGiftService
    {
        IEnumerable<GiftMask> addGift(GiftMask newGift);
        IEnumerable<GiftMask> DeleteGiftById(int Id);
        IEnumerable<GiftMask> GetGifts();
        // IEnumerable<Gifts> getGiftsById(int Id);
        IEnumerable<GiftMask> UpdateGift(GiftMask gift);
       
    }
}