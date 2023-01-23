using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.Core.Dto;
using Task6_PersonalFinance.Core.Exceptions;
using Task6_PersonalFinance.Core.Services.Interfaces;
using Task6_PersonalFinance.DataAccess.Entities;
using Task6_PersonalFinance.DataAccess.Repositories.Interfaces;

namespace Task6_PersonalFinance.Core.Services.Services
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;

        public ExpenseCategoryService(IMapper mapper, IUserContextService userContextService, IExpenseCategoryRepository expenseCategoryRepository)
        {
            _mapper = mapper;
            _userContextService = userContextService;
            _expenseCategoryRepository = expenseCategoryRepository;
        }

        public async Task Add(ExpenseCategoryDto dto)
        {
            var expenseCategory = _mapper.Map<UserExpenseCategory>(dto);
            expenseCategory.UserId = 1;
            await _expenseCategoryRepository.CreateExpenseCategoryAsync(expenseCategory);
        }

        public async Task<ICollection<ExpenseCategoryDto>> GetAllForUser()
        {
            return _mapper.Map<ICollection<ExpenseCategoryDto>>(await _expenseCategoryRepository.GetAllExpenseCategoriesAsync());
        }

        public async Task Remove(int id)
        {
            var expenseCategory = await _expenseCategoryRepository.GetExpenseCategoryByIdAsync(id);
            if (expenseCategory == null)
                throw new NotFoundException("Expense category not found");
            await _expenseCategoryRepository.DeleteExpenseCategoryAsync(expenseCategory);
        }

        public async Task Update(ExpenseCategoryDto dto)
        {
            await _expenseCategoryRepository.UpdateExpenseCategoryAsync(_mapper.Map<UserExpenseCategory>(dto));
        }
    }
}
