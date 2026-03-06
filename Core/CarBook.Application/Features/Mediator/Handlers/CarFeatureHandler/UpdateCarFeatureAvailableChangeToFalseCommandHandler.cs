using CarBook.Application.Features.Mediator.Commands.CarFeatureCommand;
using CarBook.Application.Features.Mediator.Commands.LocationComand;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandler
{
    public class UpdateCarFeatureAvailableChangeToFalseCommandHandler : IRequestHandler<UpdateCarFeatureAvailableChangeToFalseCommand>
    {
        private readonly ICarFeatureRepository _CarFeatureRepository;

        public UpdateCarFeatureAvailableChangeToFalseCommandHandler(ICarFeatureRepository _Repository)
        {
            _CarFeatureRepository = _Repository;
        }

        public async Task Handle(UpdateCarFeatureAvailableChangeToFalseCommand request, CancellationToken cancellationToken)
        {
             _CarFeatureRepository.ChangeCarFeatureAvailableToFalse(request.Id);
             
        }
    }
}
