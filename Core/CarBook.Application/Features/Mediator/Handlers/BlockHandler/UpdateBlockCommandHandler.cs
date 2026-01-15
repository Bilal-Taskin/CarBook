
using CarBook.Application.Features.Mediator.Commands.BlockCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Blocks.Mediator.Handlers.BlockHandler
{
    public class UpdateBlockCommandHandler : IRequestHandler<UpdateBlockCommand>

    {
        private readonly IRepository<Block> _repository;

        public UpdateBlockCommandHandler(IRepository<Block> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlockCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BlockID);
            values.CreatedDate = request.CreatedDate;
            values.Title = request.Title;
            values.AuthorId = request.AuthorId;
            values.CoverImageUrl = request.CoverImageUrl;
            values.CategoryId = request.CategoryId;

            await _repository.UpdateAsync(values);
        }
    }
}
