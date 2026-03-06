using CarBook.Application.Enums;
using CarBook.Application.Features.Mediator.Commands.AppUserCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandler
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;
        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                Password = request.Password,
                UserName = request.UserName,
                AppRoleId = (int)RolesType.Member,
                Mail = request.Mail,
                Name = request.Name,
                Surname = request.Surname
                

            });
        }
    }
}
