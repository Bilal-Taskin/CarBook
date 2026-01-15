
using CarBook.Application.FeatureResults.Mediator.Results.GetFeatureQueryResult;
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
    public class GetBlockByIdQueryHandler : IRequestHandler<GetBlockByIdQuery, GetBlockByIdQueryResult>
    {
        private readonly IRepository<Block> _BlockRepository;

        public GetBlockByIdQueryHandler(IRepository<Block> BlockRepository)
        {
            _BlockRepository = BlockRepository;
        }

        public async Task<GetBlockByIdQueryResult> Handle(GetBlockByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _BlockRepository.GetByIdAsync(request.Id);
            return new GetBlockByIdQueryResult
            {
                CreatedDate = values.CreatedDate,
                BlockID = values.BlockID,
                Title = values.Title,
                AuthorId = values.AuthorId,
                CoverImageUrl = values.CoverImageUrl,
                CategoryId = values.CategoryId,
                BlockDescription = values.BlockDescription
            };
        }
    }
}
