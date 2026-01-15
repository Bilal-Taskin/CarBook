
using CarBook.Application.Features.Mediator.Commands.AuthorCommand;
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
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IRepository<Author> _AuthorRepository;

        public CreateAuthorCommandHandler(IRepository<Author> AuthorRepository)
        {
            _AuthorRepository = AuthorRepository;
        }

        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _AuthorRepository.CreateAsync(new Author
            {
                AuthorName = request.AuthorName,
                ImageUrl = request.ImageUrl,
                Description = request.Description

            });
        }
    }
}
