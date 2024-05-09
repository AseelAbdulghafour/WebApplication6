using DesignDistrict.Frontend.API.WebApplication6.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Model;
using WebApplication6.Model.Request;
using WebApplication6.Model.Responses;


namespace DesignDistrict.Frontend.Controllers
{
    public class DesignDistrictController : Controller
    {

        private readonly APIClient _client;
        public DesignDistrictController(APIClient client)
        {
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            var design = await _client.GetDesigns();
            return View(design);
        }

        public async Task<IActionResult> Myposts()
        {
            var mydesigns = await _client.MyPosts();
            return View(mydesigns);
        }

        public async Task<IActionResult> DesignerList(int id)
        {
            var designers = await _client.DesignerList(id);
            return View(designers);
        }

        public async Task<IActionResult> PostDesign()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostDesign(PostRequest request)
        {
            var design = await _client.PostDesign(request);
            return RedirectToAction("MyPosts");

            if (design != null)
            {
                return RedirectToAction("Index");
            }

            //ModelState.AddModelError("", "Something happened, Could not post design");
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int postId)
        {
            var success = await _client.Delete(postId);

            if (success)
            {
                return Ok();
            }

            ModelState.AddModelError("", "Something happened, Could not delete design");
            return BadRequest(ModelState);
        }


        [HttpGet()]
        public async Task<IActionResult> FilterByPrice(decimal minPrice, decimal maxPrice)
        {
            var designs = (await _client.GetDesigns())
              
                .Where(d => d.TotalPrice >= minPrice && d.TotalPrice<= maxPrice)
                .ToList();


            return View(designs);
        }
    }


}






