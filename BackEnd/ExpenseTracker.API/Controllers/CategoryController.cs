using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("By UserId")]
        public async Task<List<CategoryDto>> GetCategories(int ReqId)
        {
            GetCategoriesQuery query = new GetCategoriesQuery();
            query.UserId = ReqId;
            return await mediator.Send(query);
        }
    }
}
