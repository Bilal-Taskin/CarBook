using CarBook.Application.Features.Mediator.Handlers.BlockHandler;
using CarBook.Application.Features.Mediator.Results.BlockResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BlockQuery
{
    public class GetAllBlocksWithAuthorQuery:IRequest<List<GetAllBlocksWithAuthorQueryResult>>
    {

    }
}
