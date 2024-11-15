using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.IdentityResults;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NazOzturkContext _context;
        public UserRepository(NazOzturkContext context)
        {
            _context = context;
        }
        public async Task<GetRoleNameQueryResult> GetRole(string userId)
        {
            var userRole =  await _context.UserRoles.FirstOrDefaultAsync(x=>x.UserId == userId);
            var roleId = userRole?.RoleId ?? "0";
            var rolename = await _context.Roles.FirstOrDefaultAsync(x=>x.Id == roleId);
            return new GetRoleNameQueryResult{RoleName = rolename?.Name };
        }

        public async Task<int> GetUserCount()
        {
            return await _context.Users.CountAsync();
        }
    }
}