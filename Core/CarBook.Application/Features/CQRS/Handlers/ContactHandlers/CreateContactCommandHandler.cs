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
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _ContactRepository;

        public CreateContactCommandHandler(IRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        public async Task Handle(CreateContactCommand command)
        {
            await _ContactRepository.CreateAsync(new Contact
            {
                Name = command.Name,
                Email = command.Email,
                Message = command.Message,
                SendDate = DateTime.Now,
                Subject = command.Subject



            });
        }
    }
}
