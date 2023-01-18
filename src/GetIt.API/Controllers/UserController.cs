using GetIt.Application.Users.Commands;
using GetIt.Application.Users.Models;
using GetIt.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GetIt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await _mediator.Send(new GetUserById(id)));
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDTO user)
        {
            return Ok(await _mediator.Send(new CreateUser(user)));
        }
    }
}
