using System;

namespace BudgetingAPI.Models{


    public class Expense
    {
        public int id { get; set; }
        public string type { get; set; }
        public string description { get; set; } 
        public bool outgoings { get; set; }
        public DateTime date { get; set; }
    }
}