using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Queries.LocationQuery;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResult;
using CarBook.Application.Features.Mediator.Results.LocationResult;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionInterface;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandler
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionQuery, GetCarDescriptionQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;
        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarDescription(request.Id);
            return new GetCarDescriptionQueryResult
            {
                CarDescriptionID = values.CarDescriptionID,
                CarID = values.CarID,
                Details = values.Details
            };
        }
    }
}
