using System.Collections.Generic;
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

        public void CreateExpense(Expense expense)
        {
            if(expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }
            _dbContext.Expenses.Add(expense);        
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _dbContext.Expenses.ToList();
        }

        public Expense GetExpenseById(int id)
        {
            return _dbContext.Expenses.FirstOrDefault(e => e.Id == id);
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >=0 );
        }
    }
}