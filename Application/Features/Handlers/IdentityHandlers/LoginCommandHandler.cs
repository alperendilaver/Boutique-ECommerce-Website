using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Application.Features.Commands.IdentityCommands;
using MediatR;
using Application.Features.Results.IdentityResults;
using Domain.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Handlers.IdentityHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        // JWT oluşturucu servisi enjekte edilebilir
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new AuthenticationResult { Success = false, Message = "Kullanıcı bulunamadı." };
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false,false);
            if (result.Succeeded)
            {
                var claims = new List<Claim>();
                if(request.Email == "tuana@gmail.com"){
                    claims.Add(new Claim(ClaimTypes.Role,"Admin"));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role,"User"));
                }
                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);
                // JWT token oluşturma işlemi burada yapılabilir
                return new AuthenticationResult { Success = true, Message = "Giriş başarılı.", Token = "JWT_TOKEN" };
            }

            return new AuthenticationResult { Success = false, Message = "Giriş başarısız." };
        }
    }
}