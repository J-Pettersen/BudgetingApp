using BudgetingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetingAPI.Data
{
    public class BudgetingDbContext : DbContext 
    {
        public BudgetingDbContext(DbContextOptions<BudgetingDbContext> options)
                : base(options)
        {                    
        }

        public DbSet<Expense> Expenses {get;set;}
    }
}