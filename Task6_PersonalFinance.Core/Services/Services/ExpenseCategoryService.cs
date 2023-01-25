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
using Task6_PersonalFinance.DataAccess.Repositories.Repositories;

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
            expenseCategory.UserId = (int)_userContextService.GetUserId;
            await _expenseCategoryRepository.CreateExpenseCategoryAsync(expenseCategory);
        }

        public async Task<ICollection<ExpenseCategoryDto>> GetAllForUser()
        {
            var userId = (int)_userContextService.GetUserId;
            return _mapper.Map<ICollection<ExpenseCategoryDto>>(await _expenseCategoryRepository.GetAllExpenseCategoriesAsync(userId));
        }

        public async Task<ExpenseCategoryDto> GetById(int id)
        {
            return _mapper.Map<ExpenseCategoryDto>(await _expenseCategoryRepository.GetExpenseCategoryByIdAsync(id));
        }

        public async Task Remove(int id)
        {
            var expenseCategory = await _expenseCategoryRepository.GetExpenseCategoryByIdAsync(id);
            if (expenseCategory == null)
                throw new NotFoundException("Expense category not found");
            await _expenseCategoryRepository.DeleteExpenseCategoryAsync(expenseCategory);
        }

        public async Task Update(int id, ExpenseCategoryDto dto)
        {
            var category = await _expenseCategoryRepository.GetExpenseCategoryByIdAsync(id);
            if (category == null)
                throw new NotFoundException("Expense category not found");

            category.Name = dto.Name;
            await _expenseCategoryRepository.UpdateExpenseCategoryAsync(category);
        }
    }
}
