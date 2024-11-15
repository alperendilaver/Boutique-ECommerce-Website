using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Commands.IdentityCommands;
using System.Security.Claims;
using Application.Features.Handlers.IdentityHandlers;
using Microsoft.AspNetCore.Cors;
using Application.Features.Queries.IdentityQuery;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CheckAuthHandler _checkAuthHandler;

        public UserController(IMediator mediator, CheckAuthHandler checkAuthHandler)
        {
            _mediator = mediator;
            _checkAuthHandler = checkAuthHandler;
        }
        
        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignupCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var result = await _mediator.Send(new LogoutCommand());
            return Ok(result);
        }
       [HttpGet("checkauth")]
        public async Task<IActionResult> CheckAuth()
        {
            var result = _checkAuthHandler.Handle(User);
            if (!string.IsNullOrEmpty(result.Id) && !string.IsNullOrEmpty(result.FullName))
            {
                return Ok(new { isAuthenticated = true, fullName = result.FullName, id = result.Id });
            }
            return Ok(new { isAuthenticated = false });
        }
        [HttpGet("getrole/{userId}")]
        public async Task<IActionResult> GetRoleName(string userId)
        {
            var result = await _mediator.Send(new GetRoleNameQuery(userId));
            if (!string.IsNullOrEmpty(result.RoleName))
            {
                return Ok(new { roleName = result.RoleName });
            }
            return Ok(new { roleName = "Unknown" });
        }
        // [HttpGet]
        // public async Task<IActionResult> GetAllUsers()
        // {
        //     var users = await _mediator.Send(new GetAllUsersQuery());
        //     return Ok(users);
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetUserById(string id)
        // {
        //     var user = await _mediator.Send(new GetUserByIdQuery { Id = id });
        //     return Ok(user);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateUser(string id, UpdateUserCommand command)
        // {
        //     command.Id = id;
        //     var result = await _mediator.Send(command);
        //     return Ok(result);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteUser(string id)
        // {
        //     var result = await _mediator.Send(new DeleteUserCommand { Id = id });
        //     return Ok(result);
        // }
    }
}