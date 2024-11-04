using ExpenseTracker.Application.DTOs;
<<<<<<< HEAD
using ExpenseTracker.Application.Requests.Commands.ExpenseCommands;
using ExpenseTracker.Application.Requests.Commands.UserCommands;
=======
using ExpenseTracker.Application.Requests.Queries;
>>>>>>> combined-app
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
<<<<<<< HEAD
    public class ExpenseController:Controller
    {
           private readonly IMediator mediator;

            public ExpenseController(IMediator mediator)
            {
                this.mediator = mediator;
            }

        [HttpGet]
        public async Task<List<ExpenseDto>> GetExpensesByUserId(int id)
=======
    public class ExpenseController : Controller
    {
        private readonly IMediator mediator;

        public ExpenseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ExpenseDTO>> GetExpensesByUserId(int id)
>>>>>>> combined-app
        {
            GetExpenseQuery query = new GetExpenseQuery();
            query.UserId = id;
            return await mediator.Send(query);
        }
<<<<<<< HEAD

        [HttpPost]
        public async Task<int> AddUser(int ReqId)
        {
            AddExpenseCommand command= new AddExpenseCommand();
            command.UserId = ReqId;
            return await mediator.Send(command);
        }
=======
>>>>>>> combined-app
    }
}
