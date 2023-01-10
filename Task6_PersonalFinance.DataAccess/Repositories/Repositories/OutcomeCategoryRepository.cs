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
    public class OutcomeCategoryRepository : IOutcomeCategoryRepository
    {
        private readonly FinancesDbContext _context;

        public OutcomeCategoryRepository(FinancesDbContext context)
        {
            _context = context;
        }

        public async Task CreateOutcomeCategoryAsync(OutcomeCategory outcomeCategory)
        {
            await _context.OutcomeCategories.AddAsync(outcomeCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOutcomeCategoryAsync(OutcomeCategory outcomeCategory)
        {
            _context.OutcomeCategories.Remove(outcomeCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<OutcomeCategory>> GetAllOutcomeCategoriesAsync()
        {
            return await _context.OutcomeCategories.ToListAsync();
        }

        public async Task<OutcomeCategory?> GetOutcomeCategoryByIdAsync(int id)
        {
            return await _context.OutcomeCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateOutcomeCategoryAsync(OutcomeCategory outcomeCategory)
        {
            _context.OutcomeCategories.Update(outcomeCategory);
            await _context.SaveChangesAsync();
        }
    }
}
