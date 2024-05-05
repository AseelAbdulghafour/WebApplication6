using Microsoft.AspNetCore.Mvc;
using static WebApplication6.Services.AuthService;

namespace WebApplication6.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class LoginController : ControllerBase
        {
            private readonly TokenService service;

            public LoginController(TokenService service)
            {
                this.service = service;
            }
            [HttpPost]
            public IActionResult Login(string username, string password)
            {
                var response = this.service.GenerateToken(username, password);

                if (response.IsValid)
                {
                    return Ok(new { Token = response.Token });
                }
                else
                {
                    return BadRequest("Username and/or Password is wrong");
                }
            }
        

        public class UserLogin()
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

    }
}
