using ECommerce.Comment.Context;
using ECommerce.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommentList() 
        { 
          var values = _commentContext.UserComments.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _commentContext.UserComments.Add(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarı ile eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
          var value =  _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();
            return Ok("Yorum başarı ile silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _commentContext.UserComments.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarı ile güncellendi");
        }

        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var values = _commentContext.UserComments.Where(c => c.ProductId ==id).ToList();
            return Ok(values);
        }

        [HttpGet("GetActiveComment")]
        public IActionResult GetActiveComment()
        {
            int value = _commentContext.UserComments.Where(c => c.Status == true).Count();
            return Ok(value);   
        }

        [HttpGet("GetPassiveComment")]
        public IActionResult GetPassiveComment()
        {
            int value = _commentContext.UserComments.Where(c => c.Status == false).Count();
            return Ok(value);
        }

        [HttpGet("GetTotalComment")]
        public IActionResult GetTotalComment()
        {
            int value = _commentContext.UserComments.Count();
            return Ok(value);
        }
    }
}
