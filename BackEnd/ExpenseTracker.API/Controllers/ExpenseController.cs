using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Requests.Commands.ExpenseCommands;
using ExpenseTracker.Application.Requests.Commands.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController:Controller
    {
           private readonly IMediator mediator;

            public ExpenseController(IMediator mediator)
            {
                this.mediator = mediator;
            }

        [HttpGet]
        public async Task<List<ExpenseDto>> GetExpensesByUserId(int id)
        {
            GetExpenseQuery query = new GetExpenseQuery();
            query.UserId = id;
            return await mediator.Send(query);
        }

        [HttpPost]
        public async Task<int> AddUser(int ReqId)
        {
            AddExpenseCommand command= new AddExpenseCommand();
            command.UserId = ReqId;
            return await mediator.Send(command);
        }
    }
}
