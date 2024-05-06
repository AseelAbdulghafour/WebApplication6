using Azure.Identity;
using DesignDistrict.Frontend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models.Entites;
using WebApplication6.Model;
using WebApplication6.Model.Request;
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
        public IEnumerable<DesignPost> GetUsersAndTheirPosts(int userId)
        {
            return _context.DesignPosts.
                Where(r=> r.User.UserAccountId == userId)
                .ToList();
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


        [HttpGet("{postId}/comments")]
        public IActionResult GetComment(int postId)
        {
            var comment = _context.DesignPosts
                .Where(r => r.Id == postId)
                .SelectMany(r => r.Comments).OrderByDescending(r => r.CreatedAt);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }
        [HttpPost("{postId}/comments")]
        public IActionResult AddComment(int postId, CreateCommentRequest request)
        {
            var design = _context.DesignPosts.Find(postId);

            var comment = new Comment
            {
                CommentText = request.Comment,
                CreatedAt = DateTime.Now, 
                Design = design

            };
            _context.Comments.Add(comment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetComment), new { postId, commentId = comment.CommentId });

        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePosts(PostRequest request)
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.UserAccounts.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var post = new DesignPost
            {
                PostDescription = request.PostDescription,
                Catagory = request.Catagory,
                User = user
               

            };

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(),
                                        "uploads", user.Username.ToString()
                                        ));
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                                        "uploads", user.Username.ToString(),
                                        $"{post.Id}_{request.PostImage.FileName}");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.PostImage.CopyToAsync(stream);
            }

            post.PostImage = $"uploads/{user.Username}/{post.Id}_{request.PostImage.FileName}";
            _context.DesignPosts.Add(post);


            _context.SaveChanges();

            return Ok(new PostCreatedResponse { Id = post.Id });
        }


    }
}



