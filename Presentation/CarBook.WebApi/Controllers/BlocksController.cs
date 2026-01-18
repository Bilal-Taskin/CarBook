
using CarBook.Application.Features.Mediator.Commands.BlockCommand;
using CarBook.Application.Features.Mediator.Queries.BlockQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlocksController : ControllerBase
    {
        private readonly IMediator _mediator; // uçakların haberleşeceği kule sistemi gibi düşünebilirsin

        public BlocksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlockList()
        {
            var values = await _mediator.Send(new GetBlockQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlock(int id)
        {
            var value = await _mediator.Send(new GetBlockByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlock(CreateBlockCommand command)
        {
            await _mediator.Send(command);
            return Ok("Block bilgisi başarılı bir şekilde eklenmiştri");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteBlock(int id)
        {
            await _mediator.Send(new RemoveBlockCommand(id));
            return Ok("Block bilgisi başarılı bir şekilde silinmiştir");
        }


        [HttpPut]

        public async Task<IActionResult> UpdateBlock(UpdateBlockCommand command)
        {
            await _mediator.Send(command);
            return Ok("Block bilgisi başarılı bir şekilde güncellenmiştir");
        }

        [HttpGet("GetLast3BlockWithAuthorList")]
        public async Task<IActionResult> GetLast3BlockWithAuthorList()
        {
            var values = await _mediator.Send(new GetLast3BlockWithAuthorQuery());
            return Ok(values); 
        }

        [HttpGet("GetAllBlocksWithAuthorList")]
        public async Task<IActionResult> GetAllBlocksWithAuthorList()
        {
            var values = await _mediator.Send(new GetAllBlocksWithAuthorQuery());
            return Ok(values);
        }

        [HttpGet("GetBlocksByAuthorId")]
        public async Task<IActionResult> GetBlocksByAuthorId(int id)
        {
            var values = await _mediator.Send(new GetBlockByAuthorIdQuery(id));
            return Ok(values);
        }

    }
}
