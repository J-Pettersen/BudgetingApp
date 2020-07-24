using System.Collections.Generic;
using AutoMapper;
using BudgetingAPI.Data;
using BudgetingAPI.DTOs;
using BudgetingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetingAPI.Controllers
{

    

    [Route("api/expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IBudgetingRepo _repository;
        private readonly IMapper _mapper;

        public ExpensesController(IBudgetingRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get api/expenses
        [HttpGet]
        public ActionResult <IEnumerable<ExpenseReadDTO>> GetAllExpenses()
        {
            var expensesList = _repository.GetAllExpenses();

            return Ok(_mapper.Map<IEnumerable<ExpenseReadDTO>>(expensesList));
        }

        //Get api/expenses/{id}
        [HttpGet("{id}")]
        public ActionResult <ExpenseReadDTO> GetExpenseById(int id)
        {
            var expense = _repository.GetExpenseById(id);

            if (expense == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ExpenseReadDTO>(expense));
        }
    }
}