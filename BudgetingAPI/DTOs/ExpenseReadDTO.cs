using System;

namespace BudgetingAPI.DTOs{


    public class ExpenseReadDTO
    {        
        public int Id { get; set; }

        public string Type { get; set; }
        
        public string Description { get; set; } 

        public bool Outgoings { get; set; }

        public decimal Amount {get; set;}

        public DateTime Date { get; set; }
    }
}