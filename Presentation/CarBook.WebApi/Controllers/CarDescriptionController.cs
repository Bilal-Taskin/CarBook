using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Queries.LocationQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionController : ControllerBase
    {
        private readonly IMediator _mediator; // uçakların haberleşeceği kule sistemi gibi düşünebilirsin

        public CarDescriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarDescriptionByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarDescriptionQuery(id));
            return Ok(values);
        }
    }
}
