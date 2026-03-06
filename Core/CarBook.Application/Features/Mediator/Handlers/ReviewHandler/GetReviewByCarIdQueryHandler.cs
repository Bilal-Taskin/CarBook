using CarBook.Application.FeatureResults.Mediator.Results.GetPricingQueryResult;
using CarBook.Application.Features.Mediator.Queries.ReviewQuery;
using CarBook.Application.Features.Mediator.Results.ReviewResult;
using CarBook.Application.Interfaces.ReviewInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandler
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _reviewRepository.GetReviewsByCarId(request.Id);
            return values.Select(x => new GetReviewByCarIdQueryResult
            {
               CarId = x.CarId,
               Comment = x.Comment,
               CustomerImage = x.CustomerImage,
               CustomerName = x.CustomerName,
               RateValue = x.RateValue,
               ReviewDate = x.ReviewDate,
               ReviewId = x.ReviewId

            }).ToList();
        }
    }
}
