using CarBook.Application.Features.Mediator.Commands.TagCloudCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandler
{
    public class CreateTagCloudCommandHandler:IRequestHandler<CreateTagCoudCommand>
    {
        private readonly IRepository<TagCloud> _TagCloudRepository;

        public CreateTagCloudCommandHandler(IRepository<TagCloud> TagCloudRepository)
        {
            _TagCloudRepository = TagCloudRepository;
        }

        public async Task Handle(CreateTagCoudCommand request, CancellationToken cancellationToken)
        {
            await _TagCloudRepository.CreateAsync(new TagCloud
            {
                Title = request.Title,
                BlockId = request.BlockId

            });
        }
    }
}
