using CarBook.Application.Features.Mediator.Commands.CommentsCommand;
using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistance.Repositories.CommentRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMediator _mediator;

        public CommentController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
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
        
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentRepository.GetById(id);
            return Ok(value);

        }

        [HttpGet("CommentListByBlock")]
        public IActionResult CommentListByBlock(int id)
        {
            var value = _commentRepository.GetCommnetsByBlockId(id);
            return Ok(value);

        }

        [HttpGet("GetCommentCountByBlockId")]
        public IActionResult GetCommentCountByBlockId(int id)
        {
            var value = _commentRepository.GetCommentCountByBlockId(id);
            return Ok(value);

        }

        [HttpPost("CreateCommentWithMediator")]
        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentsCommands command)
        {
            await _mediator.Send(command);
            return Ok("Yorum başarılı bir şekilde eklenmiştir");
        }
    }
}

