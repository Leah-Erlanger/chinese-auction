using ApiProject.Models;
using ApiProject.Repositiers;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class GiftService : IGiftService
    {

        public readonly IGiftRepository _giftRepository;
        

        public GiftService(IGiftRepository giftRepository/*,2222 services.Logger.LoggerFactory loggerFactory*/)
        {
            _giftRepository = giftRepository;
            //_loggerFactory = loggerFactory;
            //_logger = _loggerFactory.GetLogger("file");
        }
        public IEnumerable<GiftMask> GetGifts()
        {
            //_logger.Log("hiiiiiiiiiii");
            return _giftRepository.GetGifts();
        }
        public IEnumerable<GiftMask> addGift(GiftMask newGift)
        {

            return _giftRepository.addGift(newGift);
        }
        public IEnumerable<GiftMask> DeleteGiftById(int Id)
        {
           return _giftRepository.DeleteGiftById(Id);
        }
        public IEnumerable<GiftMask> UpdateGift(GiftMask gift)
        {


            return _giftRepository.UpdateGift(gift);
        }
        //    public IEnumerable<Gifts> getGiftsById(int Id)
        //    {
        //        var gifts = new List<Gifts>();
        //        var giftsList = _giftRepository.GetGifts();
        //        foreach (var g in giftsList)
        //        {
        //            if (g.Id == Id)
        //            {
        //                gifts.Add(g);
        //            }
        //        }
        //        return gifts;
        //    }
    }
}

