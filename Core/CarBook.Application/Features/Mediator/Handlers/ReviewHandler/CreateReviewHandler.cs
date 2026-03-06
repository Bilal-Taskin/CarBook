
using CarBook.Application.Features.Mediator.Commands.ReviewCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandler
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _ReviewRepository;

        public CreateReviewHandler(IRepository<Review> ReviewRepository)
        {
            _ReviewRepository = ReviewRepository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _ReviewRepository.CreateAsync(new Review
            {
                CustomerImage = request.CustomerImage,
                CustomerName = request.CustomerName,
                Comment = request.Comment,
                CarId = request.CarId,
                RateValue = request.RateValue,
                ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString())
                

            });
        }
    }
}
