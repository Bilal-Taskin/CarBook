using CarBook.Application.Features.Mediator.Commands.CommentsCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandler
{
    public class CreateCommentsHandler : IRequestHandler<CreateCommentsCommands>
    {
        private readonly IRepository<Comment> _Repository;

        public CreateCommentsHandler(IRepository<Comment> Repository)
        {
            _Repository = Repository;
        }
        public async Task Handle(CreateCommentsCommands request, CancellationToken cancellationToken)
        {
            await _Repository.CreateAsync(new Comment
            {
                   Description = request.Description,
                   BlockId = request.BlockId,
                   CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                   Name = request.Name,
                   Email = request.Email


            });
        }
    }
}
