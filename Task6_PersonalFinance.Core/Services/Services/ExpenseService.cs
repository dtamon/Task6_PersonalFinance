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
    public class ExpenseService : IExpenseService
    {
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IMapper mapper, IUserContextService userContextService, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _userContextService = userContextService;
            _expenseRepository = expenseRepository;
        }

        public async Task Add(ExpenseDto dto)
        {
            await _expenseRepository.CreateExpenseAsync(_mapper.Map<Expense>(dto));
        }

        public async Task<ICollection<ExpenseDto>> GetAllForUser()
        {
            return _mapper.Map<ICollection<ExpenseDto>>(await _expenseRepository.GetAllExpenseAsync());
        }

        public async Task<ICollection<ExpenseDto>> GetByCategoryId(int id)
        {
            return _mapper.Map<ICollection<ExpenseDto>>(await _expenseRepository.GetExpensesByCategoryIdAsync(id));
        }

        public async Task<ExpenseDto> GetByIdForUser(int id)
        {
            return _mapper.Map<ExpenseDto>(await _expenseRepository.GetAllExpenseAsync());
        }

        public async Task Remove(int id)
        {
            var expense = await _expenseRepository.GetExpenseByIdAsync(id);
            if (expense == null)
                throw new NotFoundException("Expense not found");
            await _expenseRepository.DeleteExpenseAsync(expense);
        }

        public async Task Update(int id, ExpenseDto dto)
        {
            var expense = await _expenseRepository.GetExpenseByIdAsync(id);
            if (expense == null)
                throw new NotFoundException("Expense not found");

            expense.Amount = dto.Amount;
            expense.Comment = dto.Comment;
            expense.Date = dto.Date;

            await _expenseRepository.UpdateExpenseAsync(expense);
        }
    }
}
