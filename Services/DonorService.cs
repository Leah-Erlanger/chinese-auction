using ApiProject.Models;
using System.Threading.Tasks;
using ApiProject.Repositiers;

namespace ApiProject.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;

        //private readonly ILoggerService _logger;
        //private readonly services.Logger.LoggerFactory _loggerFactory;

        public DonorService(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public IEnumerable<Donors> GetDonors()
        {
            return _donorRepository.GetDonors();
        }
        public IEnumerable<Donors> AddDonor(Donors newDonor)
        {
            return _donorRepository.AddDonor(newDonor);
        }

        public IEnumerable<Donors> DeleteDonor(int id)
        {
            return _donorRepository.DeleteDonor(id);
        }

        public IEnumerable<Donors> UpdateDonor(Donors donor)
        {

            return _donorRepository.UpdateDonor(donor);
        }

        public IEnumerable<Donors> GetDonorsById(int id)
        {
            var donor = new List<Donors>();
            var donorList = _donorRepository.GetDonors();
            foreach (var d in donorList)
            {
                if (d.Id == id)
                {
                    donor.Add(d);
                }
            }
            return donor;
        }

        public List<Gifts> GetAllGift(int id)
        {
            return _donorRepository.GetAllGift(id);
        }
        public async Task<IEnumerable<Gifts>> filterDonor(string NameDonor, string EmailDonor, string NameGift)
        {
            return await _donorRepository.filterDonor(NameDonor, EmailDonor, NameGift);
        }
    }
}
