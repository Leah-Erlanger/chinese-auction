using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        private readonly JwtTokenService _jwtTokenService;

        public LoginController(ILoginService loginService, JwtTokenService jwtTokenService)
        {
            _loginService = loginService;
            _jwtTokenService = jwtTokenService;
        }
        [HttpGet]
        public async Task<IActionResult>? GetAllUsers()

        {
            IEnumerable<Customers>? customers=await _loginService.GetAllUsers();
            if (customers.Any())
                return Ok(customers);
            return BadRequest("cant get user...");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Login login)
        {

            Customers? customers =await _loginService.Login(login.UserName, login.Password);
            List<string> IsManagers = new List<string>();
            if (customers != null)
            {
                if(customers.IsManager==false)
                {
                    IsManagers.Add("User");
                }
              else
                {
                    IsManagers.Add("Admin");
                }

                try
                {
                    var token = _jwtTokenService.GenerateJwtToken(customers, IsManagers);
                    if (token != "")
                        return Ok(new { Token = token, customers.IsManager });
                    else
                        return Ok(new { Token = "ibgi" });
                }
                catch (Exception ex)
                {
                    throw new Exception("not found" + ex);
                }  
                }

            return Unauthorized("Invalid credentials");
        }
    }
}
    
