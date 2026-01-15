using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _CategoryRepository;

        public CreateCategoryCommandHandler(IRepository<Category> CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            await _CategoryRepository.CreateAsync(new Category
            {
                Name = command.Name,
                

            });
        }
    }
}
