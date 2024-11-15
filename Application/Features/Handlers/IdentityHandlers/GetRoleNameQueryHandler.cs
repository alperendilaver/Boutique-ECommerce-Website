using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.IdentityQuery;
using Application.Features.Results.IdentityResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Handlers.IdentityHandlers
{
    public class GetRoleNameQueryHandler : IRequestHandler<GetRoleNameQuery, GetRoleNameQueryResult>
    {
        private readonly IUserRepository _userRepository;
        public GetRoleNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GetRoleNameQueryResult> Handle(GetRoleNameQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetRole(request.UserId);
        }
    }
}