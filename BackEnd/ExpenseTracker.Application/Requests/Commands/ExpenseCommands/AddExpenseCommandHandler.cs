using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Commands.ExpenseCommands
{
    public class AddExpenseCommandHandler : IRequestHandler<AddExpenseCommand, int>
    {
        private readonly ExpenseTrackerContext context;

        public AddExpenseCommandHandler(ExpenseTrackerContext Context)
        {
            context = Context;
        }

        public async Task<int> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
        {
            Expense expense = new Expense();

            expense.User = context.User.FirstOrDefault(x => x.Id == request.UserId); //set id instead of obj, use parametrized ctor
            expense.Date = DateOnly.FromDateTime(DateTime.Now);
            expense.Description = string.IsNullOrEmpty(request.Description) ? "No description provided" : request.Description; //make desc nullable in model
            expense.Amount = request.Amount;

            var categories = context.Category.Where(x => x.InBuilt == true || x.UserId == request.UserId);
            expense.Category = categories.FirstOrDefault(x => x.Name == request.CategoryName); //set id not obj //use async fns // pass cancellation token

            //add custom cat logic here
            context.Add(expense);

            return await context.SaveChangesAsync();
        }
    }
}