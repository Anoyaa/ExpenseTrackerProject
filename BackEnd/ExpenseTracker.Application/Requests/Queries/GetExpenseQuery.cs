<<<<<<< HEAD
﻿using ExpenseTracker.Application.DTOs;
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
        public class GetExpenseQuery : IRequest<List<ExpenseDto>>
        {
            public int UserId { get; set; }
        }

=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetExpenseQuery : IRequest<List<ExpenseDTO>>
    {
        public int UserId { get; set; }
    }

    public class GetExpenseQueryHandler : IRequestHandler<GetExpenseQuery, List<ExpenseDTO>>
    {
        private readonly ExpenseTrackerContext context;

        public GetExpenseQueryHandler(ExpenseTrackerContext context)
        {
            this.context = context;
        }
        public async Task<List<ExpenseDTO>> Handle(GetExpenseQuery request, CancellationToken cancellationToken)
        {
            Users requiredUser = context.Users.FirstOrDefault(x => x.Id == request.UserId);

            List<ExpenseDTO> ExpenseList = new List<ExpenseDTO>();

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
                ExpenseDTO expenseDTO = new ExpenseDTO();
                expenseDTO.Amount = retrieverdExpense.amount;
                expenseDTO.Date = retrieverdExpense.date;
                expenseDTO.Description = retrieverdExpense.description;
                expenseDTO.CategoryName = retrieverdExpense.categoryName;
                ExpenseList.Add(expenseDTO);
            }
            return await Task.FromResult(ExpenseList);
        }
    }
>>>>>>> combined-app
}
