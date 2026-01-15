
using CarBook.Application.Features.Mediator.Commands.TagCloudCommand;
using CarBook.Application.Features.Mediator.Queries.TagCloudQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudController : ControllerBase
    {
        private readonly IMediator _mediator; // uçakların haberleşeceği kule sistemi gibi düşünebilirsin

        public TagCloudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloud(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCoudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud bilgisi başarılı bir şekilde eklenmiştri");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCoudCommand(id));
            return Ok("TagCloud bilgisi başarılı bir şekilde silinmiştir");
        }


        [HttpPut]

        public async Task<IActionResult> UpdateTagCloud(UpdateTagCoudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud bilgisi başarılı bir şekilde güncellenmiştir");
        }

        [HttpGet("GetTagCloudByBlockId")]
        public async Task<IActionResult> GetTagCloudByBlockId(int id)
        {
           var values =  await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(values);
        }



    }
}
