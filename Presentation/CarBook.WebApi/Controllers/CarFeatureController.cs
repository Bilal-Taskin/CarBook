using CarBook.Application.Features.Mediator.Commands.CarFeatureCommand;
using CarBook.Application.Features.Mediator.Queries.BlockQuery;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    {

        private readonly IMediator _mediator; // uçakların haberleşeceği kule sistemi gibi düşünebilirsin

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpGet("CarFeatureChangeAvailableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Güncellem yapıldı");
        }

        [HttpGet("CarFeatureChangeAvailableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Güncellem yapıldı");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarId(CreateCarFeatureByCarCommend  createCarFeatureByCarCommend)
        {
            _mediator.Send(createCarFeatureByCarCommend);
            return Ok("Eklendi");
        } 
    }
}
