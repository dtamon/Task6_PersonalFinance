using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.Core.Dto;
using Task6_PersonalFinance.Core.Exceptions;
using Task6_PersonalFinance.Core.Services.Interfaces;
using Task6_PersonalFinance.DataAccess.Entities;
using Task6_PersonalFinance.DataAccess.Queries;
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
            var incomeCategory = _mapper.Map<UserIncomeCategory>(dto);
            incomeCategory.UserId = (int)_userContextService.GetUserId;
            await _incomeCategoryRepository.CreateIncomeCategoryAsync(incomeCategory);
        }

        public async Task<ICollection<IncomeCategoryDto>> GetAllForUser(SearchQuery query)
        {
            //var cat = await _incomeCategoryRepository.GetAllIncomeCategoriesAsync();
            //var map = _mapper.Map<ICollection<IncomeCategoryDto>>(cat);
            //return map;
            var userId = (int)_userContextService.GetUserId;
            return _mapper.Map<ICollection<IncomeCategoryDto>>(await _incomeCategoryRepository.GetAllIncomeCategoriesAsync(userId, query));
            
        }

        public async Task<IncomeCategoryDto> GetById(int id)
        {
            return _mapper.Map<IncomeCategoryDto>(await _incomeCategoryRepository.GetIncomeCategoryByIdAsync(id));
        }

        public async Task Remove(int id)
        {
            var incomeCategory = await _incomeCategoryRepository.GetIncomeCategoryByIdAsync(id);
            if (incomeCategory == null)
                throw new NotFoundException("Income category not found");
            await _incomeCategoryRepository.DeleteIncomeCategoryAsync(incomeCategory);
        }

        public async Task Update(int id, IncomeCategoryDto dto)
        {
            var category = await _incomeCategoryRepository.GetIncomeCategoryByIdAsync(id);
            if (category == null)
                throw new NotFoundException("Income category not found");

            category.Name = dto.Name;
            await _incomeCategoryRepository.UpdateIncomeCategoryAsync(category);
        }
    }
}
