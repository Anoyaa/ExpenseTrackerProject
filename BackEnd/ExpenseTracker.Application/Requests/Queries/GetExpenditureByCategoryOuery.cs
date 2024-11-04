using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Infrastructure.Data;
using MediatR;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetExpenditureByCategoryOuery : IRequest<List<CategoryExpenditureDTO>>
    {
        public int UserId { get; set; }
    }

    public class GetExpenditureByCategoryOueryHandler(ExpenseTrackerContext context) : IRequestHandler<GetExpenditureByCategoryOuery, List<CategoryExpenditureDTO>>
    {
        private readonly ExpenseTrackerContext _context = context;

        public async Task<List<CategoryExpenditureDTO>> Handle(GetExpenditureByCategoryOuery request, CancellationToken cancellationToken)
        {
            // Query to get categories with non-zero total expenses
            var categoryExpenditures = await _context.Category
                .Where(c => c.UserId == request.UserId || c.InBuilt) // Include in-built categories or categories for the given UserId
                .Select(c => new
                {
                    Name = c.Name,
                    TotalExpense = _context.Expense
                        .Where(e => e.CategoryId == c.Id) // Match the expenses with the current category
                        .Sum(e => (decimal?)e.Amount) ?? 0 // Sum the amounts, default to 0 if no expenses
                })
                .Where(c => c.TotalExpense > 0) // Filter out categories with zero total expense
                .Select(c => new CategoryExpenditureDTO
                {
                    Name = c.Name,
                    TotalExpense = c.TotalExpense
                })
                .ToListAsync(cancellationToken);

            return categoryExpenditures;
        }
    }
}

