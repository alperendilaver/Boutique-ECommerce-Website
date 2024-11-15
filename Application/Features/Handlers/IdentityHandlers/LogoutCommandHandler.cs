using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.IdentityCommands;
using Application.Features.Results.IdentityResults;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.IdentityHandlers
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, AuthenticationResult>
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutCommandHandler(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return new AuthenticationResult { Success = true, Message = "Çıkış başarılı." };
        }
    }
}