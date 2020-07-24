using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetingAPI.Models;

namespace BudgetingAPI.Data
{
    public interface IBudgetingRepo
    {       
        Task<List<Expense>> GetAllExpenses();
        Task<Expense> GetExpenseById(int id);        

        void CreateExpense(Expense expense);

        Task<bool> SaveChanges();
    }
}