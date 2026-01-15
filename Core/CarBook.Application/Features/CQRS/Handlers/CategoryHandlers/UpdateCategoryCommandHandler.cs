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
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _CategoryRepository;

        public UpdateCategoryCommandHandler(IRepository<Category> CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _CategoryRepository.GetByIdAsync(command.CategoryID);
            value.Name = command.Name;
            value.CategoryID = command.CategoryID;
            await _CategoryRepository.UpdateAsync(value);
        }
    }
}
