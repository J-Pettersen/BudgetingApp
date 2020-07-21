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
                new Expense{id=1, type="Food",description="Eggs on toast.", outgoings=true, date=DateTime.Now},
                new Expense{id=2, type="Leisure",description="Pub.", outgoings=true, date=DateTime.Now},
                new Expense{id=3, type="Salary",description="Salary.", outgoings=false, date=DateTime.Now}
            };
            return expenses;
        }

        public Expense GetExpenseById(int id)
        {
            return new Expense{id=1, type="Food",description="eggs on toast", outgoings=true, date=DateTime.Now};
        }
    }
}
