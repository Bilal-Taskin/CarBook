using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task Handel(UpdateBannerCommand command)
        {
            var values = await _bannerRepository.GetByIdAsync(command.BannerID);
            values.Description = command.Description;
            values.Title = command.Title;
            values.VideoUrl = command.VideoUrl;
            values.VideoDescription = command.VideoDescription;

            await _bannerRepository.UpdateAsync(values);
        }
    }
}
