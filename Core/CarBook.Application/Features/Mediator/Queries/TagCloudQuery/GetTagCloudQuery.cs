using CarBook.Application.Features.Mediator.Results.TagCloudResul;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudQuery
{
    public class GetTagCloudQuery:IRequest<List<GetTagCloudQueryResult>>
    {
      
    }
}
