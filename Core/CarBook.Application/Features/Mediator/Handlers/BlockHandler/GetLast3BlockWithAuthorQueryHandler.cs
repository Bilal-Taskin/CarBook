using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Features.Mediator.Queries.BlockQuery;
using CarBook.Application.Features.Mediator.Results.BlockResult;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlockInterface;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlockHandler
{
    public class GetLast3BlockWithAuthorQueryHandler : IRequestHandler<GetLast3BlockWithAuthorQuery, List<GetLast3BlockWithAuthorQueryResult>>
    {
        private readonly IBlockRepository _blockRepository;

        public GetLast3BlockWithAuthorQueryHandler(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public async Task<List<GetLast3BlockWithAuthorQueryResult>> Handle(GetLast3BlockWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _blockRepository.GetLAst3BlockWithAuthor();
            return values.Select(x => new GetLast3BlockWithAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                BlockID = x.BlockID,
                CategoryId = x.CategoryId,
                CreatedDate = x.CreatedDate,
                CoverImageUrl = x.CoverImageUrl,
                Title = x.Title,
                AuthorName= x.Author.AuthorName
            }).ToList();
        }
    }
}
