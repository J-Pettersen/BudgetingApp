using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetingAPI.Models;

namespace BudgetingAPI.Data
{
    public interface IBudgetingRepo
    {       
        Task<IEnumerable<Expense>> GetAllExpenses();
        Task<Expense> GetExpenseById(int id);        

        void CreateExpense(Expense expense);
        void UpdateExpense(Expense expense);
        void PatchExpense(Expense expense);

        Task<bool> SaveChanges();
    }
}