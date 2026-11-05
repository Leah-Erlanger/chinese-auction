using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;
        public GiftController(IGiftService giftService)
        {
            _giftService = giftService;
        }

        [HttpGet]
        public IEnumerable<GiftMask> GetGifts()
        {
            return _giftService.GetGifts();
        }

        [HttpPost]
        public IEnumerable<GiftMask> AddGift([FromBody] GiftMask gift)
        {
            var gift1 = _giftService.addGift(gift);
            return gift1;
        }
            [HttpDelete("{Id}")]
        public IActionResult deleteGift(int Id)
        {
           var gift= _giftService.DeleteGiftById(Id);
            return Ok(gift);
        }
        [HttpPut]
        public IActionResult UpdateGift([FromBody] GiftMask gift)
        {
            var gift2 = _giftService.UpdateGift(gift);
            return Ok(gift2);
        }

        //[HttpGet("{Id}")]
        //public IActionResult getGiftsById(int Id)
        //{
        //    var g = _giftService.getGiftsById(Id);
        //    if (g != null)
        //    {
        //        return Ok(g);
        //    }
        //    return BadRequest("The id is undefind");
        //}


    }
}
