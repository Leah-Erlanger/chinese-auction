using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using TasksApi.Models;

namespace ApiProject.Repositiers
{
    public class DonorRepository : IDonorRepository
    {
            private readonly ProjectDbContext _context;
            public DonorRepository(ProjectDbContext context)
            {
                _context = context;
            }

            public IEnumerable<Donors> GetDonors()
            {
                return _context.Donors.Include(e => e.GiftListForDonor).ToList();
            }

            public List<Gifts> GetAllGift(int id)
            {
                Donors? donor = _context.Donors.FirstOrDefault(d => d.Id == id);

                List<Gifts> gifts = _context.Gifts.Where(g => g.DonorId == id).ToList();

                return gifts;

            }

            public IEnumerable<Donors> AddDonor(Donors newDonor)
            {

                var donor = new Donors
                {
                    Id = newDonor.Id,
                    NameDonor = newDonor.NameDonor,
                    EmailDonor = newDonor.EmailDonor,
                    PhoneDonor = newDonor.EmailDonor

                };
                _context.Donors.Add(donor);
                _context.SaveChanges();
                return GetDonors();

            }

            public IEnumerable<Donors> DeleteDonor(int id)
            {
                Donors? donor = _context.Donors.FirstOrDefault(d => d.Id == id);
                if (donor != null)
                {
                    List<Gifts> gifts = _context.Gifts.Where(g => g.DonorId == id).ToList();
                    if (gifts.Any())
                    {
                        foreach (var item in gifts)
                        {
                            _context.Gifts.Remove(item);
                            _context.SaveChanges();
                        }
                    }
                    _context.Donors.Remove(donor);
                    _context.SaveChanges();

                }
                return GetDonors();
            }


            public IEnumerable<Donors> UpdateDonor(Donors newDonor)
            {

                var donor = new Donors
                {
                    Id = newDonor.Id,
                    NameDonor = newDonor.NameDonor,
                    EmailDonor = newDonor.EmailDonor,
                    PhoneDonor = newDonor.PhoneDonor,

                };
                _context.Donors.Update(donor);
                _context.SaveChanges();
                return GetDonors();

            }

            public async Task<IEnumerable<Gifts>> filterDonor(string NameDonor, string EmailDonor, string NameGift)
            {
                var p = _context.Gifts.Include(e => e.Donors);

                var q = _context.Gifts.Where(Gifts =>
                (NameDonor == null ? (true) : (Gifts.NameGift.Contains(NameGift)))
                && (NameGift == null ? (true) : (Gifts.Donors.NameDonor.Contains(NameDonor))
                && (EmailDonor == null ? (true) : (Gifts.Donors.EmailDonor.Contains(EmailDonor)))));

                List<Gifts> gifts = await q.ToListAsync();

                return gifts;


            }



        }
    }