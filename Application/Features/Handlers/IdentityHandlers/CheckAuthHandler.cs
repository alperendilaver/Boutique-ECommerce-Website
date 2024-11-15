using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Commands.IdentityCommands;
using Application.Features.Results.IdentityResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.IdentityHandlers
{
    public class CheckAuthHandler
    {
     
        public AuthResult Handle(ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            var FullName = user.FindFirstValue(ClaimTypes.Name);
            var result = new AuthResult
            {
                FullName = FullName,
                Id = userId
            };
            return result;
        }
    }
}