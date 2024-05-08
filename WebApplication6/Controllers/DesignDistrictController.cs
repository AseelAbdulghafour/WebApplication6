using Azure.Identity;
using DesignDistrict.Frontend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                DesignCatagory = p.DesignCatagory,
                PostImage = p.PostImage,
                TotalPrice = p.Item.Sum(r=> r.Price)
            }).ToList(); 
            return Ok(posts); 
        }



        //[HttpGet("{userId}")]
        //public IEnumerable<DesignDistrictResponse> GetUsersAndTheirPosts(int userId)
        //{
        //    return _context.DesignPosts.
        //        Where(r=> r.User.UserAccountId == userId)
        //        .ToList();
        //}

        [HttpGet("{userId}")]
        public IEnumerable<DesignDistrictResponse> GetUsersAndTheirPosts(int userId)
        {
            var userPosts = _context.DesignPosts
                .Where(r => r.User.UserAccountId == userId)
                .Include(r => r.DesignCatagory)
                .Include(r=> r.User)
                 .Include(r => r.Comments)

                .Include(r => r.Item)
                .ThenInclude(i => i.Style)
                .ToList();

            var designDistrictResponses = userPosts.Select(post => new DesignDistrictResponse
            {
                Id = post.Id,
                Description = post.PostDescription,
                Catagory = post.DesignCatagory.Name,
                Username = post.User.Username,
                Comments = post.Comments.Select(c => new CommentResponse
                {
                    Comment = $"{c.CommentText} {c.CreatedAt.ToString()}"
                }).ToList(),
                Items = post.Item.Select(item => new ItemResponse
                {
                    ItemId = item.ItemId,
                    Source = item.Source,
                    Price = item.Price,
                    //CategoryName = item.Category.Name,
                    Style = item.Style.Name
                }).ToList()
            });

            return designDistrictResponses;
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var posts = _context.DesignPosts
               .Select(p => new DesignDistrictResponse
               {
                   Id = p.Id,
                   Description = p.PostDescription,
                   Catagory = p.DesignCatagory.Name,
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
        public async Task<IActionResult> CreatePosts([FromForm] PostRequest request)
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.UserAccounts.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Create a new list of Item objects from the NewItemRequest objects in the request
            //var items = request.ItemsId.Select(id => new NewItemRequest
            //{
            //    URLLink = _context.Items.FirstOrDefault(i => i.ItemId == id).URLLink,
            //    Price = _context.Items.FirstOrDefault(i => i.ItemId == id).Price,
            //    CategoryId = _context.Items.FirstOrDefault(i => i.ItemId == id).CategoryId,
            //    StyleId = _context.Items.FirstOrDefault(i => i.ItemId == id).StyleId
            //}).ToList();

            var post = new DesignPost
            {
                PostDescription = request.PostDescription,
                DesignCatagory = _context.Categories.FirstOrDefault(c => c.CategoryId == request.CatagoryId),
                User = user,
            };

            foreach(var i in request.ItemsId)
            {
                var style = _context.Styles.Find(i.StyleId);
                var category = _context.Categories.Find(i.CategoryId);
                var itemType = _context.ItemTypes.Find(i.ItemTypeId);

                post.Item.Add(new Item
                {
                    //ItemRoomCategory = category,
                    ItemName = i.Name,
                    Price = i.Price,
                    ItemDescription = i.Name,
                    Style = style,
                    Source = i.URLLink,
                    ItemType = itemType,
                });
            }

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

        //public async Task<IActionResult> CreatePosts(PostRequest request)
        //{
        //    var username = User.FindFirst(TokenClaimsConstant.Username).Value;
        //    var user = _context.UserAccounts.FirstOrDefault(u => u.Username == username);
        //    if (user == null)
        //    {
        //        return NotFound("User not found");
        //    }
        //    //var items = _context.Items.Where(r => request.ItemsId.Contains(r.ItemId)).ToList();

        //    var post = new DesignPost
        //    {
        //        PostDescription = request.PostDescription,
        //        Catagory = request.Catagory,
        //        User = user,
        //        Item = items

        //    };

        //    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(),
        //                                "uploads", user.Username.ToString()
        //                                ));
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(),
        //                                "uploads", user.Username.ToString(),
        //                                $"{post.Id}_{request.PostImage.FileName}");

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await request.PostImage.CopyToAsync(stream);
        //    }

        //    post.PostImage = $"uploads/{user.Username}/{post.Id}_{request.PostImage.FileName}";
        //    _context.DesignPosts.Add(post);

        //    _context.SaveChanges();

        //    return Ok(new PostCreatedResponse { Id = post.Id });
        //}

    }
}



