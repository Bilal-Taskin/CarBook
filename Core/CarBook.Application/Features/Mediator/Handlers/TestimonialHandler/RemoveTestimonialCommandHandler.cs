using CarBook.Application.Features.Mediator.Commands.TestimonialCommand;
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
    public class RemoveTestimonialCommandHandler: IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _TestimonialRepository;

        public RemoveTestimonialCommandHandler(IRepository<Testimonial> TestimonialRepository)
        {
            _TestimonialRepository = TestimonialRepository;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _TestimonialRepository.GetByIdAsync(request.Id);
            await _TestimonialRepository.RemoveAsync(value);
        }

    }
}
