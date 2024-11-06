using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain
{
 
    public class Expense
    {
        public int Id { get; set; }

         //use ientitytype configuration //private set all properties everywhere
        public DateOnly Date { get; set; }
        public double Amount { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!; 

        public int CategoryId {  get; set; }    
        public Category Category { get; set; }
       
    }
}
