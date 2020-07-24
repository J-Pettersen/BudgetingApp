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

        //GET api/expenses
        [HttpGet]
        public ActionResult <IEnumerable<ExpenseReadDTO>> GetAllExpenses()
        {
            var expensesList = _repository.GetAllExpenses();

            return Ok(_mapper.Map<IEnumerable<ExpenseReadDTO>>(expensesList));
        }

        //GET api/expenses/{id}
        [HttpGet("{id}", Name="GetExpenseById")]
        public ActionResult <ExpenseReadDTO> GetExpenseById(int id)
        {
            var expense = _repository.GetExpenseById(id);

            if (expense == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ExpenseReadDTO>(expense));
        }

        //POST api/expenses
        [HttpPost]
        public ActionResult<ExpenseReadDTO> CreateExpense(ExpenseCreateDTO input)
        {
            var expenseModel = _mapper.Map<Expense>(input);
            _repository.CreateExpense(expenseModel);
            _repository.SaveChanges();
            
            var expenseReadDTO = _mapper.Map<ExpenseReadDTO>(expenseModel);

            return CreatedAtRoute(nameof(GetExpenseById), new { id =expenseReadDTO.Id }, expenseReadDTO);
        }
    }
}