using ApiProject.Models;

namespace ApiProject.Services
{
    public interface IDonorService
    {
        IEnumerable<Donors> AddDonor(Donors newDonor);
        IEnumerable<Donors> DeleteDonor(int id);
        IEnumerable<Donors> GetDonors();
        IEnumerable<Donors> GetDonorsById(int id);
        IEnumerable<Donors> UpdateDonor(Donors donor);

        List<Gifts> GetAllGift(int id);

        Task<IEnumerable<Gifts>> filterDonor(string NameDonor, string EmailDonor, string NameGift);
    }
}