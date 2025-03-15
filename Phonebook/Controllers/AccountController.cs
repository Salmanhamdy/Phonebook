using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Core.Models;
using Talabat.Core.Services;

namespace Phonebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AccountController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Appuser user)
        {
            var token = "";
            if (user.Username.ToLower() == "admin" && user.Password == "123456")
            {
                 token = _tokenService.CreateTokenAsync(user.Username,"Admin");
                return Ok(new { token });
            }

            token = _tokenService.CreateTokenAsync(user.Username, "User");
            return Ok(new { token });
        }


    }
}
