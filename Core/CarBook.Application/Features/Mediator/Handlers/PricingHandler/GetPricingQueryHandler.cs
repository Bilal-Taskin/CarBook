using CarBook.Application.FeatureResults.Mediator.Results.GetFeatureQueryResult;
using CarBook.Application.FeatureResults.Mediator.Results.GetPricingQueryResult;
using CarBook.Application.Features.Mediator.Queries.GetPricingQuery;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandler
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _pricingRepository;

        public GetPricingQueryHandler(IRepository<Pricing> pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _pricingRepository.GetAllAsync();
            return values.Select(x => new GetPricingQueryResult
            {
                PricingID = x.PricingID,    
                Name = x.Name
                

                
            }).ToList();
        }
    }
}
