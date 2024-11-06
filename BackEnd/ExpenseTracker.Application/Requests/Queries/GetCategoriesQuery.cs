using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetCategoriesQuery : IRequest<List<CategoryDTO>>
    {
        public int UserId { get; set; }
    }

    public class GetCategoriesQueryHandler(ExpenseTrackerContext context) : IRequestHandler<GetCategoriesQuery, List<CategoryDTO>>
    {
        public async Task<List<CategoryDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
           // User requiredUser = context.User.FirstOrDefault(x => x.Id == request.UserId);
            List<string> categoryList = new List<string>();

            var query = from category in context.Category
                        where category.UserId == request.UserId || category.UserId == null
                        select new CategoryDTO()
                        {
                            Name = category.Name,
                        };
            var data = query.ToListAsync(cancellationToken);


            return await data;
        }
    }
}
