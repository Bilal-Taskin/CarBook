using CarBook.Application.Features.Mediator.Queries.BlockQuery;
using CarBook.Application.Features.Mediator.Results.BlockResult;
using CarBook.Application.Interfaces.BlockInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlockHandler
{
    public class GetBlockByAuthorIdQueryHandler : IRequestHandler<GetBlockByAuthorIdQuery, List<GetBlockByAuthorIdQueryResult>>
    {
        private readonly IBlockRepository _blockRepository;

        public GetBlockByAuthorIdQueryHandler(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public async Task<List<GetBlockByAuthorIdQueryResult>> Handle(GetBlockByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _blockRepository.GetBlocksByAuthorId(request.Id);
            return values.Select(x => new GetBlockByAuthorIdQueryResult
            {
                AuthorId = x.AuthorId,
                BlockID = x.BlockID,
                AuthorName = x.Author.AuthorName,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl,
               
            }).ToList();
        }
    }
}
