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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserExpensesByCategoryId(int id)
        {
            var expenses = await _expenseService.GetByCategoryId(id);
            return Ok(expenses);
        }

        [HttpGet("getBy/{id}")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var expense = await _expenseService.GetByIdForUser(id);
            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseDto dto)
        {
            await _expenseService.Add(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(ExpenseDto dto)
        {
            await _expenseService.Update(dto);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveExpense(int id)
        {
            await _expenseService.Remove(id);
            return Ok(id);
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
            return Ok(dto);
        }

        [HttpPut(CATEGORIES + "/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, ExpenseCategoryDto dto)
        {
            await _expenseCategoryService.Update(id, dto);
            return Ok(dto);
        }

        [HttpDelete(CATEGORIES + "/{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _expenseCategoryService.Remove(id);
            return Ok(id);
        }
    }
}
