using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResult;
using CarBook.Application.Interfaces.StatistcisInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler
{
    public class GetBlockCountQueryHandler : IRequestHandler<GetBlockCountQuery, GetBlockCountQueryResult>
    {
        private readonly IStatisticsRepository repository;

        public GetBlockCountQueryHandler(IStatisticsRepository _repository)
        {
            repository = _repository;
        }

        public async Task<GetBlockCountQueryResult> Handle(GetBlockCountQuery request, CancellationToken cancellationToken)
        {
            var values = repository.GetBlockCount();
            return new GetBlockCountQueryResult
            {
              BlockCount  = values


            };
        }
    }
}
