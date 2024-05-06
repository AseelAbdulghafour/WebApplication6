using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models.Entites;
using WebApplication6.Model;
using WebApplication6.Model.Responses;
using WebApplication6.Services.ProductApi.Services;

namespace WebApplication6.Controllers
{
    [Route("api/designDistrict")]
    [ApiController]
    //[Authorize]
    public class DesignDistrictController : ControllerBase
    {

        private readonly DesignDistrictContext _context;

        public DesignDistrictController(DesignDistrictContext Context)
        {
            _context = Context;
        }


        
        [HttpGet("myposts")]
        public IActionResult GetMyPosts() 
        { 
            var username = User.FindFirst(TokenClaimsConstant.Username).Value; 
            var user = _context.UserAccounts.FirstOrDefault(u => u.Username == username); 
            if (user == null) { return NotFound("User not found"); 
        }
            var posts = _context.DesignPosts.Where(p => p.Id == user.UserAccountId).Select(p => new DesignPost 
        {
                Id = p.Id,
                PostDescription = p.PostDescription,
                Catagory = p.Catagory,
                PostImage = p.PostImage,
                TotalPrice = p.Item.Sum(r=> r.Price)
            }).ToList(); 
            return Ok(posts); 
        }

        [HttpGet("{userId}")]

        public IEnumerable<DesignPost> GetPostsByUser(int userId)
        {
            return _context.DesignPosts.Where(p => p.Id == userId);
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var posts = _context.DesignPosts
               .Select(p => new DesignDistrictResponse
               {
                   Id = p.Id,
                   Description = p.PostDescription,
                   Catagory = p.Catagory,
                   PostImage = p.PostImage,
                   Price = p.Item.Sum(r => r.Price)
               })
               .ToList();

            return Ok(posts);
        }

        
       
    }
}


