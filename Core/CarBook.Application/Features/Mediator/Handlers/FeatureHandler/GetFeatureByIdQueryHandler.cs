
using CarBook.Application.FeatureResults.Mediator.Results.GetFeatureQueryResult;
using CarBook.Application.Features.Mediator.Queries.FeatureQuery;

using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandler
{
    public class GetFeatureByIdQueryHandler :IRequestHandler<GetFeatureByIdQuery, GetFeatrueByIdQueryResult>
    {
        private readonly IRepository<Feature> _featureRepository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<GetFeatrueByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _featureRepository.GetByIdAsync(request.Id);
            return new GetFeatrueByIdQueryResult
            {
               FeatureID = values.FeatureID,
                Name = values.Name


            };
        }
    }
    }

