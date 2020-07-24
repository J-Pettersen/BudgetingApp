using AutoMapper;
using BudgetingAPI.DTOs;
using BudgetingAPI.Models;

namespace BudgetingAPI.Profiles
{
    public class ExpensesProfile : Profile
    {
        public ExpensesProfile()
        {
            CreateMap<Expense, ExpenseReadDTO>();
            CreateMap<ExpenseCreateDTO, Expense>();
        }
    }
}