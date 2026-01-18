using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistance.Repositories.CommentRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult GetAllComments()
        {
            var comments = _commentRepository.GetAll();
            return Ok(comments);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment){
        _commentRepository.Add(comment);
          return Ok("Yorum başarıyla eklendi");

        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _commentRepository.GetById(id);
            _commentRepository.Remove(value);
            return Ok("Yorum başarıyla silindi");

        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Yorum başarıyla güncellendi");

        }
        
        [HttpGet("CommentGetByList")]
        public IActionResult GetComment(int id)
        {
            var value = _commentRepository.GetById(id);
            return Ok(value);

        }
    }
}

