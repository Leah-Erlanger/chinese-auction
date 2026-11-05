
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using ApiProject.Repositiers;
using TasksApi.Models;
namespace API_PROJECT.Repositiers
{
    public class WinnersRepository : IWinnersRepository
    {
        private readonly ProjectDbContext _context;
        public WinnersRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public async Task<Customers> AddListOfWinner(int giftId)
        {
            var b = 0;
            List<int> newList = new List<int>();
            List<Baskets> ListUsers = await _context.Baskets.Where(x => x.GiftId == giftId && x.IsDraft == true).ToListAsync();
            foreach (Baskets id1 in ListUsers)
            {
                b = id1.Numgift;

                while (b > 0)
                {
                    newList.Add(id1.CustomerId);
                    b = b - 1;
                }

            }

            var a = await random(newList);
            var w = new Winners
            {
                GiftId = giftId,
                CustomerId = a.Id,
            };
            _context.Winners.Add(w);
            _context.SaveChanges();
            return a;

        }

        public async Task<Customers> random(List<int> newList)
        {
            try
            {
                if (newList == null)
                    throw new BadHttpRequestException("לא נרכשו כרטיסים עבור מתנה זו");
                if (newList.Count() == 0)
                    throw new BadHttpRequestException("לא נרכשו כרטיסים עבור מתנה זו");
                Random random = new Random();
                int index = random.Next(0, newList.Count());
                int winnerCard = newList[index];
                //_cardRepository.updateCardToWin(winnerCard.CardId);
                //winnerCard.IsWin = true
                var a = GetWinner(winnerCard);
                return await a;
            }
            catch (BadHttpRequestException ex)
            {
                throw ex;
            }

        }
        public async Task<Customers> GetWinner(int winnerCard)
        {
            Customers? c = await _context.Customers.Where(x => x.Id == winnerCard).FirstOrDefaultAsync();
            return c;
        }

        public async Task<IEnumerable<WinnerMask>> GetWinnerMask()
        {
            var s = LastPay();
            var winner = from g in _context.Gifts
                         join w in _context.Winners on g.Id equals w.GiftId
                         join c in _context.Customers on w.CustomerId equals c.Id
                         select new WinnerMask
                         {
                             Id = w.Id,
                             GiftName = g.NameGift,
                             CustomerName = c.NameCustomer,
                             Image = g.Image,
                             Email = c.EmailCustomer,
                             Phon = c.PhoneCustomer,
                             Address = c.Adress,
                             Price = g.NumBuyers * g.PriceTicket,
                             LastPrice = s

                         };
            if (winner != null)
                return await winner.ToListAsync();
            return null;

        }

        public int LastPay()
        {
            var r = 0;
            var a = _context.Baskets.Where(x => x.IsDraft == true).Select(x => x.GiftId).FirstOrDefault();
            List<int> x = _context.Gifts.Select(x => x.NumBuyers * x.PriceTicket).ToList();
            foreach (var item in x)
            {
                r = r + item;
            }
            return r;


        }


        //var gift = from g in _context.Gifts
        //           join c in _context.Category on g.CategoryId equals c.Id
        //           join d in _context.Donors on g.DonorId equals d.Id
        //           select new GiftMask
        //           {
        //               Id = g.Id,
        //               NameGift = g.NameGift,
        //               DonorName = d.NameDonor,
        //               PriceTicket = g.PriceTicket,
        //               CategoryName = c.NameCategory,
        //               Image = g.Image,
        //               Description = g.Description,
        //               NumBuyers = g.NumBuyers,


        //           };
        //    if (gift != null)
        //        return gift.ToList();
        //    return null;


    }
}
