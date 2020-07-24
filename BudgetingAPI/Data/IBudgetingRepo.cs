using System.Collections.Generic;
using BudgetingAPI.Models;

namespace BudgetingAPI.Data
{
    public interface IBudgetingRepo
    {       
        IEnumerable<Expense> GetAllExpenses();
        Expense GetExpenseById(int id);        

        void CreateExpense(Expense expense);

        bool SaveChanges();
    }
}