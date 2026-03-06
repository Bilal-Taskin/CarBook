using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Results.AppUsersResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandler
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _appuserrepository;
        private readonly IRepository<AppRole> _approlerepository;

        public GetCheckAppUserQueryHandler(IRepository<AppUser> appuserrepository, IRepository<AppRole> approlerepository)
        {
            _appuserrepository = appuserrepository;
            _approlerepository = approlerepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = await _appuserrepository.GetByFilterAsync(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user == null)
            {
                values.IsExist = false;
                return values;
            }
            else
            {
                values.IsExist = true;
                values.UserName = user.UserName;
                values.Role = (await _approlerepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;
                values.Id = user.AppUserId;
            }
            return values;
        }
    }
}
