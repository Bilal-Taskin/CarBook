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
    public class GetCarCountByKmSmallerThan1000QueryHandler : IRequestHandler<GetCarCountByKmSmallerThan1000Query, GetCarCountByKmSmallerThan1000QueryResult>
    {
        private readonly IStatisticsRepository repository;

        public GetCarCountByKmSmallerThan1000QueryHandler(IStatisticsRepository _repository)
        {
            repository = _repository;
        }

        public async Task<GetCarCountByKmSmallerThan1000QueryResult> Handle(GetCarCountByKmSmallerThan1000Query request, CancellationToken cancellationToken)
        {
            var values = repository.GetCarCountByKmSmallerThan1000();
            return new GetCarCountByKmSmallerThan1000QueryResult
            {
                CarCountByKmSmallerThan1000 = values


            };
        }
    }
}
