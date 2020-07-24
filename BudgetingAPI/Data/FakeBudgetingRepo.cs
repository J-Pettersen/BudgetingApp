using System;
using System.Collections.Generic;
using BudgetingAPI.Models;

namespace BudgetingAPI.Data
{
    public class FakeBudgetingRepo : IBudgetingRepo
    {
        public IEnumerable<Expense> GetAllExpenses()
        {
            var expenses = new List<Expense>
            {
                new Expense{Id=1, Type="Food",Description="Eggs on toast.", Outgoings=true, Amount=12.99M, Date=DateTime.Now},
                new Expense{Id=2, Type="Leisure",Description="Pub.", Outgoings=true, Amount=39.99M, Date=DateTime.Now},
                new Expense{Id=3, Type="Salary",Description="Salary.", Outgoings=false, Amount=500M,Date=DateTime.Now}
            };
            return expenses;
        }

        public Expense GetExpenseById(int id)
        {
            return new Expense{Id=1, Type="Food",Description="Eggs on toast.", Outgoings=true, Amount=12.99M, Date=DateTime.Now};
        }
    }
}
