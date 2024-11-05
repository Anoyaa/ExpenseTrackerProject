using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using Microsoft.VisualBasic;
using System.Data;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetTotalExpensesQuery : IRequest<TotalExpenseDTO>
    {
        public int UserId { get; set; }
    }

    public class GetTotalExpensesQueryHandler(ExpenseTrackerContext context) : IRequestHandler<GetTotalExpensesQuery, TotalExpenseDTO>
    {
        private readonly ExpenseTrackerContext _context = context;

        public async Task<TotalExpenseDTO> Handle(GetTotalExpensesQuery request, CancellationToken cancellationToken)
        {
            var monthlyTotal = _context.Expense.Where(e => e.UserId == request.UserId 
                                                      && e.Date.Month == DateTime.Now.Month 
                                                      && e.Date.Year == DateTime.Now.Year)
                                                .Sum(e => e.Amount);

            var yearlyTotal = _context.Expense.Where(e => e.UserId == request.UserId
                                                      && e.Date.Year == DateTime.Now.Year)
                                                .Sum(e => e.Amount);
            //week calculations
           // CultureInfo myCI = new CultureInfo("en-US");
           // Calendar myCal = myCI.Calendar;

           //// CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
           // DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
           // DateTime currentDate = DateTime.Now;
           // var currentWeek = myCal.GetWeekOfYear(currentDate, CalendarWeekRule.FirstDay, myFirstDOW);


           // var weeklyTotal = _context.Expense.Where(e => e.UserId == request.UserId
           //                                           && myCal.GetWeekOfYear(e.Date, CalendarWeekRule.FirstDay, myFirstDOW) == currentWeek
           //                                           && e.Date.Month == DateTime.Now.Month
           //                                           && e.Date.Year == DateTime.Now.Year)
           //                                     .Sum(e => e.Amount);

            TotalExpenseDTO totalExpenseDTO = new()
            {
                YearlyExpense = yearlyTotal,
                MonthlyExpense = monthlyTotal,
                //WeeklyExpense = weeklyTotal
            };
            return await Task.FromResult(totalExpenseDTO);
        }
    }
}
