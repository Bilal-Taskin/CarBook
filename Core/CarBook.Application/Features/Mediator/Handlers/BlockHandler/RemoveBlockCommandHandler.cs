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
    public class RemoveBlockCommandHandler : IRequestHandler<RemoveBlockCommand>
    {
        private readonly IRepository<Block> _repository;

        public RemoveBlockCommandHandler(IRepository<Block> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBlockCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);

        }
    }
}
