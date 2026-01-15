using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _ContactRepository;

        public RemoveContactCommandHandler(IRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }



        public async Task Handle(RemoveContactCommand command)
        {
            var value = await _ContactRepository.GetByIdAsync(command.Id);
            await _ContactRepository.RemoveAsync(value);

        }
    }
}
