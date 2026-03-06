
using CarBook.Application.Features.Mediator.Results.CarFeatureResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarFeatureQuery
{
    public class GetCarFatureByCarIdQuery:IRequest<List<GetCarFatureByCarIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCarFatureByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
