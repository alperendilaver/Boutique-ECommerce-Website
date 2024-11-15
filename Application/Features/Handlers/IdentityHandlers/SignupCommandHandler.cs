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
    public class SignupCommandHandler : IRequestHandler<SignupCommand, AuthenticationResult>
    {
        private readonly UserManager<AppUser> _userManager;

        public SignupCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthenticationResult> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmPassword)
            {
                return new AuthenticationResult { Success = false, Message = "Şifreler eşleşmiyor." };
            }

            var user = new AppUser {FullName = request.FullName, UserName = request.Email, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                // JWT token oluşturma işlemi burada yapılabilir
                return new AuthenticationResult { Success = true, Message = "Kayıt başarılı.", Token = "JWT_TOKEN" };
            }

            return new AuthenticationResult { Success = false, Message = "Kayıt başarısız: " + string.Join(", ", result.Errors.Select(e => e.Description)) };
        }
    }
}