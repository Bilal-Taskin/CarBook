using CarBook.Application.Features.Mediator.Queries.TestimonialQuery;
using CarBook.Application.Features.Mediator.Results.TestimonialResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandler
{
    public class GetTestimonialByIdQueryHandler:IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {

        private readonly IRepository<Testimonial> _TestimonialRepository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> TestimonialRepository)
        {
            _TestimonialRepository = TestimonialRepository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _TestimonialRepository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                Comment = values.Comment,
                ImageUrl = values.ImageUrl,
                Name = values.Name,
                TestimonialID = values.TestimonialID,
                Title = values.Title
            };
        }

    }
}
