using CarBook.Application.Features.Mediator.Commands.ReviewCommand;
using CarBook.Application.Features.Mediator.Queries.LocationQuery;
using CarBook.Application.Features.Mediator.Queries.ReviewQuery;
using CarBook.Application.Validators.ReviewValidator;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator; // uçakların haberleşeceği kule sistemi gibi düşünebilirsin

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ReviewListByCarId(int id)
        {
            var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(CreateReviewCommand createReviewCommand)
        {
            CreateReviewValidator validationRules = new CreateReviewValidator();
            var validationResult = validationRules.Validate(createReviewCommand);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _mediator.Send(createReviewCommand);
            return Ok("Ekleme işlemi gerçekleşti");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand updateReviewCommand)
        {
            await _mediator.Send(updateReviewCommand);
            return Ok("Ekleme işlemi gerçekleşti");
        }
    }
}
