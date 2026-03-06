using CarBook.Application.Features.Mediator.Commands.CarFeatureCommand;
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
    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommend>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CreateCarFeatureByCarCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateCarFeatureByCarCommend request, CancellationToken cancellationToken)
        {
            _carFeatureRepository.CreateCarFeatureByCar(new CarFeature
            {
                Avaliable = false,
                CarID = request.CarID,
                FeatureID = request.FeatureID

            });
        }
    }
}
