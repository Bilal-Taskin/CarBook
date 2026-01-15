using CarBook.Application.FeatureResults.Mediator.Results.GetFeatureQueryResult;
using CarBook.Application.FeatureResults.Mediator.Results.GetPricingQueryResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.GetPricingQuery
{
    public class GetPricingQuery: IRequest<List<GetPricingQueryResult>>
    {
    }
}
