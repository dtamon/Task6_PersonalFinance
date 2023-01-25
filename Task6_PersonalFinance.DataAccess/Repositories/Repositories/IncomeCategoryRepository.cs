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
    public class IncomeCategoryRepository : IIncomeCategoryRepository
    {
        private readonly FinancesDbContext _context;

        public IncomeCategoryRepository(FinancesDbContext context)
        {
            _context = context;
        }

        public async Task CreateIncomeCategoryAsync(UserIncomeCategory incomeCategory)
        {
            await _context.UserIncomeCategories.AddAsync(incomeCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIncomeCategoryAsync(UserIncomeCategory incomeCategory)
        {
            _context.UserIncomeCategories.Remove(incomeCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UserIncomeCategory>> GetAllIncomeCategoriesAsync(int userId)
        {
            return await _context.UserIncomeCategories.Include(x => x.Incomes).Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<UserIncomeCategory?> GetIncomeCategoryByIdAsync(int id)
        {
            return await _context.UserIncomeCategories.Include(x => x.Incomes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateIncomeCategoryAsync(UserIncomeCategory incomeCategory)
        {
            _context.UserIncomeCategories.Update(incomeCategory);
            await _context.SaveChangesAsync();
        }
    }
}
