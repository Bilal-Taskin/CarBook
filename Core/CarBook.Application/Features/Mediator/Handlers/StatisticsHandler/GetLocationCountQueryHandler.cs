using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResult;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.StatistcisInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler
{
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        private readonly IStatisticsRepository repository;

        public GetLocationCountQueryHandler(IStatisticsRepository _repository)
        {
            repository = _repository;
        }

        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var values = repository.GetLocationCount();
            return new GetLocationCountQueryResult
            {
                LocationCount = values


            };
        }
    }
    
}
