using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;
using TasksApi.Models;

namespace ApiProject.Repositiers
{
    public class GiftRepository : IGiftRepository
    {
        private readonly ProjectDbContext _context;

        public GiftRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public IEnumerable<GiftMask> GetGifts()
        {
            var gift = from g in _context.Gifts
                       join c in _context.Category on g.CategoryId equals c.Id
                       join d in _context.Donors on g.DonorId equals d.Id
                       select new GiftMask
                       {
                           Id = g.Id,
                           NameGift = g.NameGift,
                           DonorName = d.NameDonor,
                           PriceTicket = g.PriceTicket,
                           CategoryName = c.NameCategory,
                           Image = g.Image,
                           Description = g.Description,
                           NumBuyers = g.NumBuyers,

                       };
            if (gift != null)
                return gift.ToList();
            return null;


            //return _context.Gifts.ToList();
        }

        public IEnumerable<GiftMask> addGift(GiftMask newGift)
        {
                var gift = new Gifts
                {
                    Id = newGift.Id,
                    NameGift = newGift.NameGift,
                    DonorId = _context.Donors.Where(d => d.NameDonor == newGift.DonorName).Select(d => d.Id).FirstOrDefault(),
                    PriceTicket = newGift.PriceTicket,
                    CategoryId = _context.Category.Where(c => c.NameCategory == newGift.CategoryName).Select(c => c.Id).FirstOrDefault(),
                    Image = newGift.Image,
                    Description = newGift.Description,
                    NumBuyers = newGift.NumBuyers,
                };
                _context.Gifts.Add(gift);
                _context.SaveChanges();
                return GetGifts();
     
        }
        public IEnumerable<GiftMask> DeleteGiftById(int Id)
        {
            Gifts? thisGift = _context.Gifts.Find(Id);
            _context.Gifts.Remove(thisGift);
            _context.SaveChanges();
            return GetGifts();
        }

        public int getDonorID(string name)
        {

            return _context.Donors.FirstOrDefault(d => d.NameDonor == name).Id;

        }
        public int getCategoryID(string name)
        {

            return _context.Category.FirstOrDefault(c => c.NameCategory == name).Id;

        }
        public IEnumerable<GiftMask> UpdateGift(GiftMask newGift)
        {
            var gift = new Gifts
            {
                Id = newGift.Id,
                NameGift = newGift.NameGift,
                DonorId = _context.Donors.Where(d => d.NameDonor == newGift.DonorName).Select(d => d.Id).FirstOrDefault(),
                PriceTicket = newGift.PriceTicket,
                CategoryId = _context.Category.Where(c => c.NameCategory == newGift.CategoryName).Select(c => c.Id).FirstOrDefault(),
                Image = newGift.Image,
                Description = newGift.Description,
                NumBuyers = newGift.NumBuyers,
            };
            _context.Gifts.Update(gift);
            _context.SaveChanges();
            return GetGifts();
        }


    }
}
    

