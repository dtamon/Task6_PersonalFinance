using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task6_PersonalFinance.Core.Dto;
using Task6_PersonalFinance.Core.Services.Interfaces;
using Task6_PersonalFinance.Core.Services.Services;

namespace Task6_PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeCategoryService _incomeCategoryService;
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeCategoryService incomeCategoryService, IIncomeService incomeService)
        {
            _incomeCategoryService = incomeCategoryService;
            _incomeService = incomeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserIncomes()
        {
            var incomes = await _incomeService.GetAllForUser();
            return Ok(incomes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserIncomesByCategoryId(int id)
        {
            var incomes = await _incomeService.GetByCategoryId(id);
            return Ok(incomes);
        }

        [HttpGet("getBy/{id}")]
        public async Task<IActionResult> GetIncomeById(int id)
        {
            var income = await _incomeService.GetByIdForUser(id);
            return Ok(income);
        }

        [HttpPost]
        public async Task<IActionResult> AddIncome(IncomeDto dto)
        {
            await _incomeService.Add(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncome(IncomeDto dto)
        {
            await _incomeService.Update(dto);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveIncome(int id)
        {
            await _incomeService.Remove(id);
            return Ok(id);
        }

        const string CATEGORIES = "categories";

        [HttpGet(CATEGORIES)]
        public async Task<IActionResult> GetUserCategories()
        {
            var categories = await _incomeCategoryService.GetAllForUser();
            return Ok(categories);
        }

        [HttpGet(CATEGORIES + "/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _incomeCategoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost(CATEGORIES)]
        public async Task<IActionResult> AddCategory(IncomeCategoryDto dto)
        {
            await _incomeCategoryService.Add(dto);
            return Ok(dto);
        }

        [HttpPut(CATEGORIES + "/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, IncomeCategoryDto dto)
        {
            await _incomeCategoryService.Update(id, dto);
            return Ok(dto);
        }

        [HttpDelete(CATEGORIES + "/{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _incomeCategoryService.Remove(id);
            return Ok(id);
        }

    }
}
