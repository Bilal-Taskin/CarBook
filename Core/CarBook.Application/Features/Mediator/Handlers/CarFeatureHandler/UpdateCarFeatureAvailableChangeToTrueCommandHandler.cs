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
    public class UpdateCarFeatureAvailableChangeToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvailableChangeToTrueCommand>
    {
        private readonly ICarFeatureRepository _CarFeatureRepository;

        public UpdateCarFeatureAvailableChangeToTrueCommandHandler(ICarFeatureRepository _Repository)
        {
            _CarFeatureRepository = _Repository;
        }

        public async Task Handle(UpdateCarFeatureAvailableChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            _CarFeatureRepository.ChangeCarFeatureAvailableToTrue(request.Id);

        }
    }
}
