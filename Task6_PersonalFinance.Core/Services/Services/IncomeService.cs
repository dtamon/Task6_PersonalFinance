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
    public class IncomeService : IIncomeService
    {
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IIncomeRepository _incomeRepository;

        public IncomeService(IMapper mapper, IUserContextService userContextService, IIncomeRepository incomeRepository)
        {
            _mapper = mapper;
            _userContextService = userContextService;
            _incomeRepository = incomeRepository;
        }

        public async Task Add(IncomeDto dto)
        {
            await _incomeRepository.CreateIncomeAsync(_mapper.Map<Income>(dto));
        }

        public async Task<ICollection<IncomeDto>> GetAllForUser()
        {
            return _mapper.Map<ICollection<IncomeDto>>(await _incomeRepository.GetAllIncomesAsync());
        }

        public async Task<ICollection<IncomeDto>> GetByCategoryId(int id)
        {
            return _mapper.Map<ICollection<IncomeDto>>(await _incomeRepository.GetIncomesByCategoryIdAsync(id));
        }

        public async Task<IncomeDto> GetByIdForUser(int id)
        {
            return _mapper.Map<IncomeDto>(await _incomeRepository.GetIncomeByIdAsync(id));
        }

        public async Task Remove(int id)
        {
            var income = await _incomeRepository.GetIncomeByIdAsync(id);
            if (income == null)
                throw new NotFoundException("Income not found");
            await _incomeRepository.DeleteIncomeAsync(income);
        }

        public async Task Update(int id, IncomeDto dto)
        {
            var income = await _incomeRepository.GetIncomeByIdAsync(id);
            if (income == null)
                throw new NotFoundException("Expense not found");

            income.Amount = dto.Amount;
            income.Comment = dto.Comment;
            income.Date = dto.Date;
            await _incomeRepository.UpdateIncomeAsync(income);
        }
    }
}
