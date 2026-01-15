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
    public class GetTagCloudQueryHandler:IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _TagCloudRepository;

    public GetTagCloudQueryHandler(IRepository<TagCloud> TagCloudRepository)
    {
        _TagCloudRepository = TagCloudRepository;
    }

    public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
    {
        var values = await _TagCloudRepository.GetAllAsync();
        return values.Select(x => new GetTagCloudQueryResult
        {
            Title = x.Title,
            TagCloudId = x.TagCloudId,
            BlockId = x.BlockId
        }).ToList();
    }
}
}
