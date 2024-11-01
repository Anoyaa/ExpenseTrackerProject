using ExpenseTracker.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetCategoriesQuery:IRequest<List<CategoryDto>>
    {
    
        public int UserId { get; set; }
    }
}
