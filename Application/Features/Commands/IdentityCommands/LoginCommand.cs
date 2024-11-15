using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.IdentityResults;
using MediatR;

namespace Application.Features.Commands.IdentityCommands
{
    public class LoginCommand: IRequest<AuthenticationResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}