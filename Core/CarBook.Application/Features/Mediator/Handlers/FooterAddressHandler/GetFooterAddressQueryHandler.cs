using CarBook.Application.FeatureResults.Mediator.Results.GetFeatureQueryResult;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResult;
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
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _footerAddressRepository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _footerAddressRepository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                Phone = x.Phone,
                Email = x.Email,
                Address = x.Address,
                Description = x.Description,
                FooterAddressID = x.FooterAddressID


            }).ToList();
        }
    }
}
