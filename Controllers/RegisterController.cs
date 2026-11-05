using ApiProject.Models;
using ApiProject.Repositiers;
using ApiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        [HttpPost]
        public IActionResult? Register([FromBody] Customers newUser)
        {
            //check for unique 
            _registerService.addUser(newUser);
               return Ok(newUser);
        }
    }
}
