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

        public async Task CreateIncomeCategoryAsync(IncomeCategory incomeCategory)
        {
            await _context.IncomeCategories.AddAsync(incomeCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIncomeCategoryAsync(IncomeCategory incomeCategory)
        {
            _context.IncomeCategories.Remove(incomeCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<IncomeCategory>> GetAllIncomeCategoriesAsync()
        {
            return await _context.IncomeCategories.ToListAsync();
        }

        public async Task<IncomeCategory?> GetIncomeCategoryByIdAsync(int id)
        {
            return await _context.IncomeCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateIncomeCategoryAsync(IncomeCategory incomeCategory)
        {
            _context.IncomeCategories.Update(incomeCategory);
            await _context.SaveChangesAsync();
        }
    }
}
