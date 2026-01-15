using CarBook.Application.Features.Mediator.Queries.BlockQuery;
using CarBook.Application.Features.Mediator.Results.BlockResult;
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
    public class GetBlockQueryHandler : IRequestHandler<GetBlockQuery, List<GetBlockQueryResult>>
    {
        private readonly IRepository<Block> _BlockRepository;

        public GetBlockQueryHandler(IRepository<Block> BlockRepository)
        {
            _BlockRepository = BlockRepository;
        }

        public async Task<List<GetBlockQueryResult>> Handle(GetBlockQuery request, CancellationToken cancellationToken)
        {
            var values = await _BlockRepository.GetAllAsync();
            return values.Select(x => new GetBlockQueryResult
            {
                AuthorId = x.AuthorId,
                BlockID = x.BlockID,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
            }).ToList();
        }
    }
}
