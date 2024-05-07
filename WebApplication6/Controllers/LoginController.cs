using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models.Entites;
using SQLitePCL;
using WebApplication6.Model;
using WebApplication6.Model.Request;
using WebApplication6.Services;
using static WebApplication6.Services.TokenService;

namespace WebApplication6.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class LoginController : ControllerBase
        {
            private readonly TokenService _service;
            private readonly DesignDistrictContext _context;
        

        public LoginController(TokenService service, DesignDistrictContext context)
            {
                _service = service;
                _context = context;
            }
            [HttpPost("Login")]
            public IActionResult Login(string username, string password)
            {
                var response = _service.GenerateToken(username, password);

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


        [HttpPost("Registor")]
        public IActionResult Registor(SignupRequest request)
        {
            
            var newUser = UserAccount.Create(request.Username, request.Password, request.Email, request.PhoneNumber, request.Address, request.IsAdmin);
            newUser.Username = request.Username;
            newUser.Email = request.Email;
            newUser.Address = request.Address;
            newUser.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password);

            newUser.PhoneNumber = request.PhoneNumber;
            newUser.IsAdmin = request.IsAdmin;

            _context.UserAccounts.Add(newUser);
            _context.SaveChanges();

            return Created(nameof(UserAccount), newUser);

            return Ok(new { Message = "User Created" });

        }
       

    }
}
