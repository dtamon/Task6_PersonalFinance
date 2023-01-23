using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.DataAccess.Context;
using Task6_PersonalFinance.DataAccess.Entities;
using Task6_PersonalFinance.DataAccess.Repositories.Interfaces;

namespace Task6_PersonalFinance.DataAccess.Repositories.Repositories
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly FinancesDbContext _context;

        public ExpenseCategoryRepository(FinancesDbContext context)
        {
            _context = context;
        }

        public async Task CreateExpenseCategoryAsync(UserExpenseCategory outcomeCategory)
        {
            await _context.UserExpenseCategories.AddAsync(outcomeCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExpenseCategoryAsync(UserExpenseCategory outcomeCategory)
        {
            _context.UserExpenseCategories.Remove(outcomeCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UserExpenseCategory>> GetAllExpenseCategoriesAsync()
        {
            return await _context.UserExpenseCategories.Include(x => x.Expenses).ToListAsync();
        }

        public async Task<UserExpenseCategory?> GetExpenseCategoryByIdAsync(int id)
        {
            return await _context.UserExpenseCategories.Include(x => x.Expenses).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateExpenseCategoryAsync(UserExpenseCategory outcomeCategory)
        {
            _context.UserExpenseCategories.Update(outcomeCategory);
            await _context.SaveChangesAsync();
        }
    }
}
