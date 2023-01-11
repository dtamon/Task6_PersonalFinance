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

        public async Task CreateOutcomeCategoryAsync(UserExpenseCategory outcomeCategory)
        {
            await _context.UserExpenseCategories.AddAsync(outcomeCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOutcomeCategoryAsync(UserExpenseCategory outcomeCategory)
        {
            _context.UserExpenseCategories.Remove(outcomeCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UserExpenseCategory>> GetAllOutcomeCategoriesAsync()
        {
            return await _context.UserExpenseCategories.ToListAsync();
        }

        public async Task<UserExpenseCategory?> GetOutcomeCategoryByIdAsync(int id)
        {
            return await _context.UserExpenseCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateOutcomeCategoryAsync(UserExpenseCategory outcomeCategory)
        {
            _context.UserExpenseCategories.Update(outcomeCategory);
            await _context.SaveChangesAsync();
        }
    }
}
