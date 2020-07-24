using AutoMapper;
using BudgetingAPI.Data;
using BudgetingAPI.DTOs;
using BudgetingAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;

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
            var expenseRepoModel = await _repository.GetExpenseById(id);

            if(expenseRepoModel == null)
            {
                return NotFound();
            }

            _mapper.Map(expenseUpdateDTO, expenseRepoModel);

            _repository.UpdateExpense(expenseRepoModel);

            await _repository.SaveChanges();
            
            return NoContent();
        }


        //PATCH api/expenses/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchExpense(int id, JsonPatchDocument<ExpenseUpdateDTO> patchDoc)
        {
            var expenseRepoModel = await _repository.GetExpenseById(id);

            if(expenseRepoModel == null)
            {
                return NotFound();
            }

            var expenseToPatch = _mapper.Map<ExpenseUpdateDTO>(expenseRepoModel);
            patchDoc.ApplyTo(expenseToPatch, ModelState);

            if(!TryValidateModel(expenseToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(expenseToPatch, expenseRepoModel);

            _repository.UpdateExpense(expenseRepoModel);

            await _repository.SaveChanges();
            
            return NoContent();
        }


        //DELETE api/expenses/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpense(int id)
        {
            var expenseRepoModel = await _repository.GetExpenseById(id);

            if(expenseRepoModel == null)
            {
                return NotFound();
            }

            _repository.DeleteExpense(expenseRepoModel);

            await _repository.SaveChanges();

            return NoContent();
        }
    }

}