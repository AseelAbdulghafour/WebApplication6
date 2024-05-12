using DesignDistrict.Frontend.API.WebApplication6.API;
using DesignDistrict.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication6.Model;

namespace DesignDistrict.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly APIClient _client;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, APIClient client)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetDesigns();
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
