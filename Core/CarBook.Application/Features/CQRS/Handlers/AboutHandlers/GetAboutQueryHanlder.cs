using CarBook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Domain.Entities;
using System.Security.Cryptography.X509Certificates;
using CarBook.Application.Features.CQRS.Results.AboutResult;


namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHanlder
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHanlder(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutByIdQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAboutByIdQueryResult
            {
                AboutID= x.AboutID,
                Description=x.Description,
                Title = x.Title,
                Imageurl = x.Imageurl

            }).ToList();
        }
    }
}
