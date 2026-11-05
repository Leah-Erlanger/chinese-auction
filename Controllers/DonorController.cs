using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }
        [Authorize(Roles = "User,Admin")]

        [Route("GetDonors")]
        [HttpGet]
        public IEnumerable<Donors> GetDonors()
        {
            return _donorService.GetDonors();
        }
        [Authorize(Roles = "User,Admin")]

        [Route("GetAllGift")]
        [HttpGet]
        public List<Gifts> GetAllGift(int id)
        {

            return _donorService.GetAllGift(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IEnumerable<Donors> AddDonor([FromBody] Donors donor)
        {
            var donor2 = _donorService.AddDonor(donor);
            return donor2;
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteDonor(int id)
        {
            _donorService.DeleteDonor(id);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateDonor([FromBody] Donors donor)
        {
            var donor2 = _donorService.UpdateDonor(donor);
            return Ok(donor2);
        }


        [HttpGet]
        public async Task<IEnumerable<Gifts>> FilterDonors(string NameDonor, string EmailDonor, string NameGift)
        {
            return await _donorService.filterDonor(NameDonor, EmailDonor, NameGift);
        }
    }
}
