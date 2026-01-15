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
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _ContactRepository;

        public UpdateContactCommandHandler(IRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var value = await _ContactRepository.GetByIdAsync(command.ContactID);
            value.Name = command.Name;
            value.Email = command.Email;
            value.Message = command.Message;
            value.Subject = command.Subject;
            value.SendDate = command.SendDate;
             
            await _ContactRepository.UpdateAsync(value);
        }
    }
}
