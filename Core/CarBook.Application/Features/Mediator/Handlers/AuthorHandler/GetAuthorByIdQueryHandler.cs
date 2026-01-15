
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
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _AuthorRepository;

        public GetAuthorByIdQueryHandler(IRepository<Author> AuthorRepository)
        {
            _AuthorRepository = AuthorRepository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _AuthorRepository.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                
                AuthorId = request.Id,
                Description = values.Description,
                ImageUrl = values.ImageUrl,
                AuthorName = values.AuthorName,

            };
        }


    }
}
