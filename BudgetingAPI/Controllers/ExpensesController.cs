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
        public async Task<ActionResult<IEnumerable<ExpenseReadDTO>>> GetAllExpenses()
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
        public async Task<ActionResult<ExpenseReadDTO>> CreateExpense(ExpenseCreateDTO expenseCreateDTO)
        {
            var expenseModel = _mapper.Map<Expense>(expenseCreateDTO);
            _repository.CreateExpense(expenseModel);
            await _repository.SaveChanges();
            
            var expenseReadDTO = _mapper.Map<ExpenseReadDTO>(expenseModel);

            return CreatedAtRoute(nameof(GetExpenseById), new { id = expenseReadDTO.Id }, expenseReadDTO);
        }

        //PUT api/expenses/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExpense(int id, ExpenseUpdateDTO expenseUpdateDTO)
        {
            var expenseRepo = await _repository.GetExpenseById(id);

            if(expenseRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(expenseUpdateDTO, expenseRepo);

            _repository.UpdateExpense(expenseRepo);

            await _repository.SaveChanges();
            
            return NoContent();
        }

        //Patch api/expenses/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchExpense(int id, ExpensePatchDTO expensePatchDTO)
        {
            var expenseRepo = await _repository.GetExpenseById(id);

            if(expenseRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(expensePatchDTO, expenseRepo);

            _repository.PatchExpense(expenseRepo);

            await _repository.SaveChanges();
            
            return NoContent();
        }
    }
}