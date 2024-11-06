using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Infrastructure.Data;
using MediatR;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class LoginQuery : IRequest<int>  //returns userid
    {
        public string phone { get; set; }
        public string password { get; set; }
    }

    public class LoginQueryHandler(ExpenseTrackerContext context) : IRequestHandler<LoginQuery, int>
    {
        private readonly ExpenseTrackerContext _context = context;

        public async Task<int> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var requiredUser = _context.User.FirstOrDefault(x => x.PhoneNumber == request.phone
                                                                  && x.Password == request.password);
            if (requiredUser == null)
            {
                return 0;
            }

            return await Task.FromResult(requiredUser.Id);
        }
    }
}
