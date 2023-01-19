using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task6_PersonalFinance.Core.Dto;
using Task6_PersonalFinance.Core.Services.Interfaces;
using Task6_PersonalFinance.Core.Services.Services;

namespace Task6_PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var expenses = await _incomeService.GetAllForUser();
            return Ok(expenses);
        }

        [HttpPost]
        public async Task<IActionResult> AddIncome(IncomeDto dto)
        {
            await _incomeService.Add(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncome(IncomeDto dto)
        {
            await _incomeService.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveIncome(int id)
        {
            await _incomeService.Remove(id);
            return Ok();
        }

        const string CATEGORIES = "categories";

        [HttpGet(CATEGORIES)]
        public async Task<IActionResult> GetUserCategories()
        {
            var categories = await _incomeCategoryService.GetAllForUser();
            return Ok(categories);
        }

        [HttpPost(CATEGORIES)]
        public async Task<IActionResult> AddCategory(IncomeCategoryDto dto)
        {
            await _incomeCategoryService.Add(dto);
            return Ok();
        }

        [HttpPut(CATEGORIES + "/{id}")]
        public async Task<IActionResult> UpdateCategory(IncomeCategoryDto dto)
        {
            await _incomeCategoryService.Update(dto);
            return Ok();
        }

        [HttpDelete(CATEGORIES + "/{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _incomeCategoryService.Remove(id);
            return Ok();
        }

    }
}
