using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.IdentityResults;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        public Task <GetRoleNameQueryResult> GetRole(string userId);
        public Task<int> GetUserCount();
    }
}