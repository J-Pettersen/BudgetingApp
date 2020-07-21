using System.Collections.Generic;
using BudgetingAPI.Data;
using BudgetingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetingAPI.Controllers
{

    

    [Route("api/expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IBudgetingRepo _repository;

        public ExpensesController(IBudgetingRepo repository)
        {
            _repository = repository;
        }

        //Get api/expenses
        [HttpGet]
        public ActionResult <IEnumerable<Expense>> GetAllExpenses()
        {
            var expensesList = _repository.GetAllExpenses();

            return Ok(expensesList);
        }

        //Get api/expenses/{id}
        [HttpGet("{id}")]
        public ActionResult <Expense> GetExpenseById(int id)
        {
            var expense = _repository.GetExpenseById(id);

            return Ok(expense);
        }
    }
}