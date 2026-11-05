using ApiProject.Models;

namespace ApiProject.Services
{
    public interface IWinnersService
    {
        Task<Customers> AddListOfWinner(int giftId);
        Task<IEnumerable<WinnerMask>> GetWinnerMask();
    }
}