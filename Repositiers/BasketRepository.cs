
using ApiProject.Models;
using ApiProject.Repositiers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using TasksApi.Models;
using static Azure.Core.HttpHeader;
using static System.Net.Mime.MediaTypeNames;
namespace API_PROJECT.Repositiers
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ProjectDbContext _context;
        public BasketRepository(ProjectDbContext context)
        {
            _context = context;
        }



        public int AddToBasket(int giftId, string userId)
        {
            var a = getNumGift(giftId, userId);
            if (a == 0)
            {
                var b = new Baskets
                {
                    CustomerId = Int32.Parse(userId),
                    GiftId = giftId,
                    Numgift = 1,
                    IsDraft = false
                };
                _context.Baskets.Add(b);
                _context.SaveChanges();
            }
            else
            {
                Baskets b = _context.Baskets.Where(c => c.CustomerId == Int32.Parse(userId) && c.GiftId == giftId).FirstOrDefault();
                b.Numgift = a + 1;
                _context.Baskets.Update(b);
                _context.SaveChanges();
            }



            return 1;

        }

        public int getNumGift(int GiftId, string CustomerId)
        {
            var r = 0;
            var a = _context.Baskets.Where(c => c.CustomerId == Int32.Parse(CustomerId) && c.GiftId == GiftId).Select(c => c.Numgift).FirstOrDefault();
            IQueryable<Baskets> x = _context.Baskets.Where(c => c.CustomerId == Int32.Parse(CustomerId) && c.GiftId == GiftId);
            foreach (Baskets id1 in x)
            {
                if (id1.IsDraft == false)
                {
                    r = 0;
                    break;
                }

                r = 1;

            }
            if (a == null || r != 0)
                return 0;

            else return a;
        }


        public async Task<IEnumerable<Baskets>> a(int num, int giftId, string userId)
        {
            Baskets r = await _context.Baskets.Where(x => x.GiftId == giftId && x.CustomerId == Int32.Parse(userId) && x.IsDraft == false).FirstOrDefaultAsync();
            r.Numgift = num;
            _context.Baskets.Update(r);
            _context.SaveChanges();
            return await GetGiftOfUser(userId);
        }


        public async Task<IEnumerable<Baskets>> GetGiftOfUser(string userId)
        {
            var g = _context.Baskets.Include(x => x.Gifts)
                .Where(x => x.CustomerId == Int32.Parse(userId) && x.IsDraft == false)
                .Select(x => new Baskets
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    Gifts = x.Gifts,
                    Numgift = x.Numgift,
                    //_context.Baskets.Where(u => u.GiftId == x.Id && u.CustomerId == Int32.Parse(userId) && u.IsDraft == false).Select(x => x.NumGift).FirstOrDefault(),
                    IsDraft = false


                }

               );

            var res = await g.ToListAsync();

            return res;
        }


        public async Task<IEnumerable<Baskets>> delete(int id, string userId)
        {
            var id1 = _context.Baskets.Where(c => c.Id == id).Select(x => x.GiftId).FirstOrDefault();
            var a = _context.Baskets.Where(c => c.CustomerId == Int32.Parse(userId) && c.GiftId == id1 && c.IsDraft == false).Select(c => c.Id).FirstOrDefault();
            Baskets? thisGift = _context.Baskets.Where(x => x.Id == a).FirstOrDefault();
            _context.Baskets.Remove(thisGift);
            _context.SaveChanges();
            return await GetGiftOfUser(userId);

        }
        public async Task<IEnumerable<Baskets>> buy(string userId)
        {


            List<Baskets> x = await _context.Baskets.Where(c => c.CustomerId == Int32.Parse(userId)).ToListAsync();

            foreach (Baskets id1 in x)
            {




                Gifts g = await _context.Gifts.FirstOrDefaultAsync(x => x.Id == id1.GiftId);
                if (id1.IsDraft == false)
                    g.NumBuyers = g.NumBuyers + id1.Numgift;
                var r = _context.Baskets.Where(x => x.CustomerId == Int32.Parse(userId) && x.GiftId == g.Id && x.IsDraft == false).Select(x => x.Numgift).FirstOrDefault();
                //if (id1.CustomerId == Int32.Parse(userId) && id1.GiftId == g.Id && id1.IsDraft == false)
                //{

                //}
                id1.IsDraft = true;
                _context.Baskets.Update(id1);
            }

            _context.SaveChanges();
            return await GetGiftOfUser(userId);
        }



    }








}

