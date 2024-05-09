

    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using DesignDistrict.Frontend.API.WebApplication6.API;
using WebApplication6.Model.Request;
using ProductApi.Models.Requests;

namespace DesignDistrict.Frontend.Controllers

{
    public class AccountController : Controller
        {

            private readonly APIClient _api;
            public AccountController(APIClient api)
            {
                _api = api;
            }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
            public async Task<IActionResult> Register(SignupRequest req)
            {
                var created = await _api.Register(req);
                if (created)
                {
                    return Redirect("/DesignDistrict/Index");
                }
                ModelState.AddModelError("Username", "Something happened, Could not create user");
                return View(req);
            }
            public IActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Login(UserLoginRequest request)
            {

                var jwtToken = await _api.Login(request.Username, request.Password);
                if (jwtToken != "")
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtSecurityToken = handler.ReadJwtToken(jwtToken);

                    var claimsIdentity = new ClaimsIdentity(jwtSecurityToken.Claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);


                    var authProperties = new AuthenticationProperties
                    { IsPersistent = false, AllowRefresh = true };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    HttpContext.Session.SetString("Token", jwtToken);
                    HttpContext.Response.Cookies.Append("Token", jwtToken);

                    return Redirect("/Home/Index");
                }


                ModelState.AddModelError("Username", "Invalid Username and/or Password");
                return View();
            }
            public IActionResult Logout()
            {
                HttpContext.SignOutAsync();
                return Redirect("/Home/Index");
            }
            public IActionResult Denied()
            {
                return View();
            }
        }
    }







