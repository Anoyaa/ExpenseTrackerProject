using ExpenseTracker.Application.Requests.Commands.UserCommands;
using ExpenseTracker.Application.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<int> AddUser(AddUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("Login")]
        public async Task<int> LoginCheck([FromBody] LoginQuery loginQuery)
        {            
            return await _mediator.Send(loginQuery);
        }
    }
}
