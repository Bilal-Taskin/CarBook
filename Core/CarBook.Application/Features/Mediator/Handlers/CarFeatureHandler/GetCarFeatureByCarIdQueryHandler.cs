using CarBook.Application.Features.Mediator.Queries.CarFeatureQuery;
using CarBook.Application.Features.Mediator.Queries.LocationQuery;
using CarBook.Application.Features.Mediator.Results.BlockResult;
using CarBook.Application.Features.Mediator.Results.CarFeatureResult;
using CarBook.Application.Features.Mediator.Results.LocationResult;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlockInterface;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandler
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFatureByCarIdQuery, List<GetCarFatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _CarFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository _Repository)
        {
            _CarFeatureRepository = _Repository;
        }

        public async Task<List<GetCarFatureByCarIdQueryResult>> Handle(GetCarFatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _CarFeatureRepository.GetCarFeaturesByCarId(request.Id);
            return values.Select(x => new GetCarFatureByCarIdQueryResult
            {
                Avaliable = x.Avaliable,
                CarFeatureID = x.CarFeatureID,
                FeatureID = x.FeatureID,
                Name = x.Feature.Name



            }).ToList();
        }
    }
}
