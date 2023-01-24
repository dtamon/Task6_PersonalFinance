using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task6_PersonalFinance.Core.Dto;
using Task6_PersonalFinance.Core.Services.Interfaces;
using Task6_PersonalFinance.Core.Services.Services;

namespace Task6_PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseCategoryService _expenseCategoryService;
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseCategoryService expenseCategoryService, IExpenseService expenseService)
        {
            _expenseCategoryService = expenseCategoryService;
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserExpenses()
        {
            var expenses = await _expenseService.GetAllForUser();
            return Ok(expenses);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseDto dto)
        {
            await _expenseService.Add(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(ExpenseDto dto)
        {
            await _expenseService.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveExpense(int id)
        {
            await _expenseService.Remove(id);
            return Ok();
        }

        const string CATEGORIES = "categories";

        [HttpGet(CATEGORIES)]
        public async Task<IActionResult> GetUserCategories()
        {
            var categories = await _expenseCategoryService.GetAllForUser();
            return Ok(categories);
        }

        [HttpGet(CATEGORIES + "/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _expenseCategoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost(CATEGORIES)]
        public async Task<IActionResult> AddCategory(ExpenseCategoryDto dto)
        {
            await _expenseCategoryService.Add(dto);
            return Ok();
        }

        [HttpPut(CATEGORIES + "/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, ExpenseCategoryDto dto)
        {
            await _expenseCategoryService.Update(id, dto);
            return Ok();
        }

        [HttpDelete(CATEGORIES + "/{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _expenseCategoryService.Remove(id);
            return Ok();
        }
    }
}
