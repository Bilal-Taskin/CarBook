using CarBook.Application.Features.Mediator.Queries.TagCloudQuery;
using CarBook.Application.Features.Mediator.Results.TagCloudResul;
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
   public  class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _TagCloudRepository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> TagCloudRepository)
        {
            _TagCloudRepository = TagCloudRepository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _TagCloudRepository.GetByIdAsync(request.Id);
            return new GetTagCloudByIdQueryResult
            {
                Title = values.Title,
                TagCloudId = values.TagCloudId,
                BlockId = values.BlockId


            };
        }
    }
}
