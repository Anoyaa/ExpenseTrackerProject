using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetExpenseQueryHandler : IRequestHandler<GetExpenseQuery, List<ExpenseDto>>
    {
        private readonly ExpenseTrackerContext context;

        public GetExpenseQueryHandler(ExpenseTrackerContext context)
        {
            this.context = context;
        }
        public async Task<List<ExpenseDto>> Handle(GetExpenseQuery request, CancellationToken cancellationToken)
        {
            Users requiredUser = context.Users.FirstOrDefault(x => x.Id == request.UserId);

            List<ExpenseDto> ExpenseList = new List<ExpenseDto>();

            var query = from expense in context.Expense
                        join user in context.Users on expense.Id equals user.Id
                        join category in context.Category on expense.CategoryId equals category.Id
                        select new
                        {
                            amount = expense.Amount,
                            date = expense.Date,
                            description = expense.Description,
                            categoryName = category.Name,
                        };

            foreach (var retrieverdExpense in query)
            {
                ExpenseDto expenseDTO = new ExpenseDto();
                expenseDTO.Amount = retrieverdExpense.amount;
                expenseDTO.Date = retrieverdExpense.date;
                expenseDTO.Description = retrieverdExpense.description;
                expenseDTO.CategoryName = retrieverdExpense.categoryName;
                ExpenseList.Add(expenseDTO);
            }
            return await Task.FromResult(ExpenseList);
        }
    }
}
