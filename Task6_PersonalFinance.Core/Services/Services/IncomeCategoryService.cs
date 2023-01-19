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
    public class IncomeCategoryService : IIncomeCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IIncomeCategoryRepository _incomeCategoryRepository;

        public IncomeCategoryService(IMapper mapper, IUserContextService userContextService, IIncomeCategoryRepository incomeCategoryRepository)
        {
            _mapper = mapper;
            _userContextService = userContextService;
            _incomeCategoryRepository = incomeCategoryRepository;
        }

        public async Task Add(IncomeCategoryDto dto)
        {
            await _incomeCategoryRepository.CreateIncomeCategoryAsync(_mapper.Map<UserIncomeCategory>(dto));
        }

        public async Task<ICollection<IncomeCategoryDto>> GetAllForUser()
        {
            return _mapper.Map<ICollection<IncomeCategoryDto>>(await _incomeCategoryRepository.GetAllIncomeCategoriesAsync());
        }

        public async Task Remove(int id)
        {
            var incomeCategory = await _incomeCategoryRepository.GetIncomeCategoryByIdAsync(id);
            if (incomeCategory == null)
                throw new NotFoundException("Income category not found");
            await _incomeCategoryRepository.DeleteIncomeCategoryAsync(incomeCategory);
        }

        public async Task Update(IncomeCategoryDto dto)
        {
            await _incomeCategoryRepository.UpdateIncomeCategoryAsync(_mapper.Map<UserIncomeCategory>(dto));
        }
    }
}
