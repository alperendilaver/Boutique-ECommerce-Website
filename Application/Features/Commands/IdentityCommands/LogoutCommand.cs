using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.IdentityResults;
using MediatR;
using Microsoft.AspNetCore.Http.Features.Authentication;

namespace Application.Features.Commands.IdentityCommands
{
    public class LogoutCommand : IRequest<AuthenticationResult>
    {
        
    }
}