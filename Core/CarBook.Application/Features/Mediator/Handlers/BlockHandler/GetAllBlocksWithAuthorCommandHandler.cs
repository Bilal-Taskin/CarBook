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
    public class GetAllBlocksWithAuthorCommandHandler: IRequestHandler<GetAllBlocksWithAuthorQuery, List<GetAllBlocksWithAuthorQueryResult>>
    {
        private readonly IBlockRepository _blockRepository;

        public GetAllBlocksWithAuthorCommandHandler(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public async Task<List<GetAllBlocksWithAuthorQueryResult>> Handle(GetAllBlocksWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _blockRepository.GetAllBlocksWithAuthor    ();
            return values.Select(x => new GetAllBlocksWithAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                BlockID = x.BlockID,
                CategoryId = x.CategoryId,
                CreatedDate = x.CreatedDate,
                CoverImageUrl = x.CoverImageUrl,
                Title = x.Title,
                AuthorName = x.Author.AuthorName,
                BlockDescription =x.BlockDescription
    }).ToList();
        }
    }
}

