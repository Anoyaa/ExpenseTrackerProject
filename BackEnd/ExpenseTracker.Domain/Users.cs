﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain
{
    public class Users
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string PhoneNumber {  get; set; }    
        public string Password { get; set; }

    }
}