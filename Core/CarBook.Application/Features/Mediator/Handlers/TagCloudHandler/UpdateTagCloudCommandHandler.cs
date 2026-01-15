
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
    public class UpdateTagCloudCommandHandler: IRequestHandler<UpdateTagCoudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCoudCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TagCloudId);
            values.Title = request.Title;
            values.TagCloudId = request.TagCloudId;
            values.BlockId = request.BlockId;


            await _repository.UpdateAsync(values);
        }
    
    }
}
