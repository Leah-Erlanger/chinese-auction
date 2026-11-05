using ApiProject.Models;

namespace ApiProject.Repositiers
{
    public interface IGiftRepository
    {
        IEnumerable<GiftMask> addGift(GiftMask newGift);
        IEnumerable<GiftMask> DeleteGiftById(int Id);
        IEnumerable<GiftMask> GetGifts();
        IEnumerable<GiftMask> UpdateGift(GiftMask newGift);
        int getDonorID(string name);
        int getCategoryID(string name);
    }
}