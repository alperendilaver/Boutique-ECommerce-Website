using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.IdentityQuery;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Handlers.IdentityHandlers
{
    public class GetUserCountQueryHandler : IRequestHandler<GetUserCountQuery, int>
    {
        private readonly IUserRepository _userRepository;
        public GetUserCountQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(GetUserCountQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserCount();
        }
    }
}