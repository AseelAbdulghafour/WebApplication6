using DesignDistrict.Frontend.API.WebApplication6.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DesignDistrict.Frontend.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class DesignDistrictController : Controller
    {

        private readonly APIClient _client;
        public DesignDistrictController(APIClient client)
        {
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            var design = await _client.GetBanks();
            return View(design.Data);
        }
        public async Task<IActionResult> Upload()
        {
            return View();
        }


    }
}






