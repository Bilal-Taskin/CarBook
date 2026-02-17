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
   public  class GetCarCountByFuelGasolineOrDieselQueryHandler : IRequestHandler<GetCarCountByFuelGasolineOrDieselQuery, GetCarCountByFuelGasolineOrDieselQueryResult>
    {
        private readonly IStatisticsRepository repository;

        public GetCarCountByFuelGasolineOrDieselQueryHandler(IStatisticsRepository _repository)
        {
            repository = _repository;
        }

        public async Task<GetCarCountByFuelGasolineOrDieselQueryResult> Handle(GetCarCountByFuelGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var values = repository.GetCarCountByFuelGasolineOrDiesel();
            return new GetCarCountByFuelGasolineOrDieselQueryResult
            {
               CarCountByFuelGasolineOrDiesel = values


            };
        }
    }
}
