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
    public class CreateBlockCommandHandler : IRequestHandler<CreateBlockCommand>
    {
        private readonly IRepository<Block> _BlockRepository;

        public CreateBlockCommandHandler(IRepository<Block> BlockRepository)
        {
            _BlockRepository = BlockRepository;
        }

        public async Task Handle(CreateBlockCommand request, CancellationToken cancellationToken)
        {
            await _BlockRepository.CreateAsync(new Block
            {
               CreatedDate = request.CreatedDate,
               Title = request.Title,
               AuthorId = request.AuthorId,
               CoverImageUrl = request.CoverImageUrl,
               CategoryId = request.CategoryId,




            });
        }
    }
}
