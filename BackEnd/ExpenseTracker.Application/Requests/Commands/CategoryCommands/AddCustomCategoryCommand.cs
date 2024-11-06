using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;

namespace ExpenseTracker.Application.Requests.Commands.CategoryCommands
{
    public class AddCustomCategoryCommand : IRequest<int>
    {
        public int userId { get; set; }
        public string name { get; set; }
    }

    public class AddCustomCategoryCommandHandler(ExpenseTrackerContext context) : IRequestHandler<AddCustomCategoryCommand, int>
    {
        private readonly ExpenseTrackerContext _context = context;

        public async Task<int> Handle(AddCustomCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new();
            category.Name = request.name;
            category.UserId = request.userId;
            category.InBuilt = false;

            _context.Category.Add(category);
            return await _context.SaveChangesAsync();

        }
    }
}