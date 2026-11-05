using ApiProject.Models;
namespace ApiProject.Repositiers
{
    public interface IDonorRepository
    {
        IEnumerable<Donors> AddDonor(Donors newDonor);
        IEnumerable<Donors> DeleteDonor(int id);
        IEnumerable<Donors> GetDonors();
        IEnumerable<Donors> UpdateDonor(Donors newDonor);

        public List<Gifts> GetAllGift(int id);
        Task<IEnumerable<Gifts>> filterDonor(string NameDonor, string EmailDonor, string NameGift);
    }
}
