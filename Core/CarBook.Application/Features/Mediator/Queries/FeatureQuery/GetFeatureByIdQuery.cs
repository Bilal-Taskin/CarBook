using CarBook.Application.FeatureResults.Mediator.Results.GetFeatureQueryResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FeatureQuery
{
    public class GetFeatureByIdQuery:IRequest<GetFeatrueByIdQueryResult>
    {
        public int  Id { get; set; }

        public GetFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
