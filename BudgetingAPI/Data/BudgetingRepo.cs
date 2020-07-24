using System;
using BudgetingAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace BudgetingAPI.Data
{
    public class BudgetingRepo : IBudgetingRepo
    {
        private readonly BudgetingDbContext _dbContext;
        public BudgetingRepo(BudgetingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Expense>> GetAllExpenses()
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

        public void UpdateExpense(Expense expense)
        {
            //No implementation currently needed.
        }

        public void DeleteExpense(Expense expense)
        {
             if(expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }
            _dbContext.Expenses.Remove(expense);
        }
    

        public async Task<bool> SaveChanges()
        {
            return (await _dbContext.SaveChangesAsync() >=0 );
        }

        
    }        
}