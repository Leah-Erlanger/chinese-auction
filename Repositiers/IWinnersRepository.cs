using ApiProject.Models;

namespace API_PROJECT.Repositiers
{
    public interface IWinnersRepository
    {
        Task<Customers> AddListOfWinner(int giftId);
        Task<Customers> GetWinner(int winnerCard);
        Task<IEnumerable<WinnerMask>> GetWinnerMask();
        Task<Customers> random(List<int> newList);
    }
}