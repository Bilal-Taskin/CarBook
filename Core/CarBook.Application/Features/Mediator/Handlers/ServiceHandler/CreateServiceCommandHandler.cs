using CarBook.Application.Features.Mediator.Commands.CreateServiceCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandler
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IRepository<Service> _serviceRepository;

        public CreateServiceCommandHandler(IRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            await _serviceRepository.CreateAsync(new Service
            {
                IconUrl = request.IconUrl,
                Title = request.Title,
                Description = request.Description,

            });
        }
    }
}
