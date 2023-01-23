using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.Core.Dto;
using Task6_PersonalFinance.DataAccess.Entities;

namespace Task6_PersonalFinance.Core
{
    public class PersonalFinanceMappingProfile : Profile
    {
        public PersonalFinanceMappingProfile()
        {
            CreateMap<UserIncomeCategory, IncomeCategoryDto>()
                .ForMember(d => d.SumAmount, o => o.MapFrom(s => s.Incomes.Sum(item => item.Amount)));
            CreateMap<IncomeCategoryDto, UserIncomeCategory>();

            CreateMap<UserExpenseCategory, ExpenseCategoryDto>()
                .ForMember(d => d.SumAmount, o => o.MapFrom(s => s.Expenses.Sum(item => item.Amount)));
            CreateMap<ExpenseCategoryDto, UserExpenseCategory>();

            CreateMap<Income, IncomeDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));
            CreateMap<IncomeDto, Income>();

            CreateMap<Expense, ExpenseDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));
            CreateMap<ExpenseDto, Expense>();
        }
    }
}
