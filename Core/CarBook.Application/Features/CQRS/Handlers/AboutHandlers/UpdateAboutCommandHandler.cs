using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _aboutRepository;

        public UpdateAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task Handel(UpdateAboutCommand command)
        {
            var values = await _aboutRepository.GetByIdAsync(command.AboutID);
            values.Description=command.Description;
            values.Title = command.Title;
            values.Imageurl = command.Imageurl;
            await _aboutRepository.UpdateAsync(values);
        }
    }
}
