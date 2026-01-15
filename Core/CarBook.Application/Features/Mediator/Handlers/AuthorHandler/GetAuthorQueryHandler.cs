using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Authors.Mediator.Handlers.AuthorHandler
{
   public  class GetAuthorQueryHandler:IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _AuthorRepository;

        public GetAuthorQueryHandler(IRepository<Author> AuthorRepository)
        {
            _AuthorRepository = AuthorRepository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _AuthorRepository.GetAllAsync();
            return values.Select(x => new GetAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName = x.AuthorName,
                ImageUrl = x.ImageUrl,
                Description = x.Description
            }).ToList();
        }
    }
}
