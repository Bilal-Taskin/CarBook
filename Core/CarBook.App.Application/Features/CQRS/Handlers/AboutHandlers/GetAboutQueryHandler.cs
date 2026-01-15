
using CarBook.App.Application.Interfaces;
using CarBook.AppDomains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.App.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
      private readonly IRepository<About> _aboutRepository;
        public GetAboutQueryHandler(IRepository<Domain.Entities.About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
    }
}
