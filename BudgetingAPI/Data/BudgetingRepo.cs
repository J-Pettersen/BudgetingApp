using System.Collections.Generic;
using BudgetingAPI.Models;
using System.Linq;

namespace BudgetingAPI.Data
{
    public class BudgetingRepo : IBudgetingRepo
    {
        private readonly BudgetingDbContext _dbContext;
        public BudgetingRepo(BudgetingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _dbContext.Expenses.ToList();
        }

        public Expense GetExpenseById(int id)
        {
            return _dbContext.Expenses.FirstOrDefault(e => e.Id == id);
        }
    }
}