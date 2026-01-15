using CarBook.Application.Features.Mediator.Commands.CreatePricingCommand;
using CarBook.Application.Features.Mediator.Commands.RemovePricingCommand;
using CarBook.Application.Features.Mediator.Commands.UpdatePricingCommand;
using CarBook.Application.Features.Mediator.Queries.GetPricingByIdQuery;
using CarBook.Application.Features.Mediator.Queries.GetPricingQuery;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {

        private readonly IMediator _mediator; // uçakların haberleşeceği kule sistemi gibi düşünebilirsin

        public PricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Fiyat başarılı bir şekilde eklenmiştri");
        }

        [HttpDelete]

        public async Task<IActionResult> DeletePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Fiyat başarılı bir şekilde silinmiştir");
        }


        [HttpPut]

        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Fiyat başarılı bir şekilde güncellenmiştir");
        }
    }
}
