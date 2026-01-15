using CarBook.Application.FeatureResults.Mediator.Results.GetFeatureQueryResult;
using CarBook.Application.FeatureResults.Mediator.Results.GetPricingByIdQueryResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.GetPricingByIdQuery
{
    public class GetPricingByIdQuery:IRequest<GetPricingByIdQueryResult>
    {
        public int  Id { get; set; }

        public GetPricingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
