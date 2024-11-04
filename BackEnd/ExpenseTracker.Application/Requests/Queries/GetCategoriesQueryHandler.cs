using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly ExpenseTrackerContext context;

        public GetCategoriesQueryHandler(ExpenseTrackerContext Context)
        {
            context = Context;
        }
        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var list = await Task.Run(() =>
            {
                List<CategoryDto> categoriesList = new List<CategoryDto>();
                var categories = context.Category.Where(x => x.InBuilt==true ||x.UserId==request.UserId);
                foreach (var cat in categories)
                {
                    CategoryDto category = new CategoryDto();
                    category.Name = cat.Name;

                    categoriesList.Add(category);
                }
                return categoriesList;
            });
            return list;
        }
    }
}
