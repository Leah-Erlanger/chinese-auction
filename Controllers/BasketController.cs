using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Security.Claims;
//using TasksApi.Services;

namespace API_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketConreoller : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly JwtTokenService _jwtTokenService;
        //private static readonly HttpContext httpContext = HttpContext;
        public BasketConreoller(IBasketService basketService, JwtTokenService jwtTokenService)
        {
            _basketService = basketService;
            _jwtTokenService = jwtTokenService;

        }


        //int userId = int.Parse(httpContext.User.FindFirst(ClaimTypes.NameIdentifier?.value)
        [Authorize(Roles = "User,Admin")]

        [HttpPost]

        public async Task<IActionResult> AddToBasket([FromBody] BasketId basketId)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var userId = _jwtTokenService.ExtractUserIdFromToken(token);
            var x = _basketService.AddToBasket(basketId.GiftId, userId);

            return Ok(x);


        }
        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public async Task<IActionResult> GetGiftOfUser()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = _jwtTokenService.ExtractUserIdFromToken(token);
            var x = await _basketService.GetGiftOfUser(userId);
            if (x != null)
                return Ok(x);
            else
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "User,Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var userId = _jwtTokenService.ExtractUserIdFromToken(token);
            var x = await _basketService.delete(id, userId);
            if (x != null)
                return Ok(x);
            else return BadRequest();

        }
        [Authorize(Roles = "User,Admin")]
        [HttpPut]
        public async Task<IActionResult> buy([FromBody] BasketId basketId)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var userId = _jwtTokenService.ExtractUserIdFromToken(token);
            var x = await _basketService.buy(userId);
            if (x != null)
                return Ok(x);
            else return BadRequest();
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPut("{num}/{giftId}")]
        //[Route("addmin")]
        public async Task<IActionResult> a(int num, int giftId)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var userId = _jwtTokenService.ExtractUserIdFromToken(token);
            var a = await _basketService.a(num, giftId, userId);
            if (a != null)
                return Ok(a);

            else
            {
                return BadRequest();
            }
        }



        //int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}
