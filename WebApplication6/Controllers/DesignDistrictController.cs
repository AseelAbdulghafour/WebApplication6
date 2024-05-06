﻿using Azure.Identity;
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

        //[HttpGet("{userId}")]

        //public IEnumerable<DesignPost> GetPostsByUser(int userId)
        //{
        //    return _context.DesignPosts.Where(p => p.Id == userId);
        //}

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
            var comment = _context.DesignPosts.Where(r=> r.Id == postId).SelectMany(r=> r.Comments);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }
        [HttpPost("{postId}/comments")]
        public IActionResult AddComment(int postId, Comment request)
        {
           

            var comment = new Comment
            {
                CommentId = request.CommentId,
                CommentText = request.CommentText,
                CreatedAt = DateTime.UtcNow
              
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetComment), new { postId, commentId = comment.CommentId }, comment);

        }

    }
}


