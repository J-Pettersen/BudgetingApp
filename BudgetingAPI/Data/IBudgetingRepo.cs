using BudgetingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetingAPI.Data
{
    public interface IBudgetingRepo
    {       
        Task<IEnumerable<Expense>> GetAllExpenses();
        Task<Expense> GetExpenseById(int id);        

        void CreateExpense(Expense expense);
        void UpdateExpense(Expense expense);
        void DeleteExpense(Expense expense);

        Task<bool> SaveChanges();
    }
}