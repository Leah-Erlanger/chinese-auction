using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class WinnersController : ControllerBase
    {
        private readonly IWinnersService _winnerService;
        public WinnersController(IWinnersService winnerService)
        {
            _winnerService = winnerService;

        }
        [HttpPost]
        public async Task<IActionResult> AddListOfWinner([FromBody] BasketId giftId)
        {
            var a= await _winnerService.AddListOfWinner(giftId.GiftId);
            return Ok(a);
        }
        [HttpGet]
        public async Task<IActionResult> GetWinnerMask()
        {
            var w = await _winnerService.GetWinnerMask();
            return Ok(w);
        }
    }
}
