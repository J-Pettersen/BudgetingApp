using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetingAPI.Models;
using System.Linq;
using System;


namespace BudgetingAPI.Data
{
    public class BudgetingRepo : IBudgetingRepo
    {
        private readonly BudgetingDbContext _dbContext;
        public BudgetingRepo(BudgetingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Expense>> GetAllExpenses()
        {
            return await _dbContext.Expenses.ToListAsync();
        }

        public async Task<Expense> GetExpenseById(int id)
        {
            return await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        }

        public void CreateExpense(Expense expense)
        {
            if(expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }
            _dbContext.Expenses.Add(expense);        
        }

        public async Task<bool> SaveChanges()
        {
            return (await _dbContext.SaveChangesAsync() >=0 );
        }
    }
}