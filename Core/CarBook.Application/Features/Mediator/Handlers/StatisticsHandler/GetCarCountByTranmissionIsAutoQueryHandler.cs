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
    public class GetCarCountByTranmissionIsAutoQueryHandler : IRequestHandler< GetCarCountByTranmissionIsAutoQuery,  GetCarCountByTranmissionIsAutoQueryResult>
    {
        private readonly IStatisticsRepository repository;

        public  GetCarCountByTranmissionIsAutoQueryHandler(IStatisticsRepository _repository)
        {
            repository = _repository;
        }

        public async Task< GetCarCountByTranmissionIsAutoQueryResult> Handle( GetCarCountByTranmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var values = repository. GetCarCountByTranmissionIsAuto();
            return new  GetCarCountByTranmissionIsAutoQueryResult
            {
                CarCountByTranmissionIsAuto = values


            };
        }
    }
}
