using CarBook.Application.Features.Mediator.Commands.FeatureCommand;
using CarBook.Application.Features.Mediator.Commands.FooterAddressCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandler
{
    public class CreateFooterAddressCommandHandler: IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _FooterAddressRepository;

        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> FooterAddressRepository)
        {
            _FooterAddressRepository = FooterAddressRepository;
        }



        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await _FooterAddressRepository.CreateAsync(new FooterAddress
            {
                Address = request.Address,
                Description = request.Description,
                Email = request.Email,
                Phone = request.Phone


            });
        }
    }
}
