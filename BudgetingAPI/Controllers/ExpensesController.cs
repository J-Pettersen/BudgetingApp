using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<List<ExpenseReadDTO>>> GetAllExpenses()
        {
            var expensesList = await _repository.GetAllExpenses();

            return _mapper.Map<List<ExpenseReadDTO>>(expensesList);
        }

        //GET api/expenses/{id}
        [HttpGet("{id}", Name="GetExpenseById")]
        public async Task<ActionResult<ExpenseReadDTO>> GetExpenseById(int id)
        {
            var expense = await _repository.GetExpenseById(id);

            if (expense == null)
            {
                return NotFound();
            }
            return _mapper.Map<ExpenseReadDTO>(expense);
        }

        //POST api/expenses
        [HttpPost]
        public async Task<ActionResult<ExpenseReadDTO>> CreateExpense(ExpenseCreateDTO input)
        {
            var expenseModel = _mapper.Map<Expense>(input);
            _repository.CreateExpense(expenseModel);
            await _repository.SaveChanges();
            
            var expenseReadDTO = _mapper.Map<ExpenseReadDTO>(expenseModel);

            return CreatedAtRoute(nameof(GetExpenseById), new { id =expenseReadDTO.Id }, expenseReadDTO);
        }
    }
}