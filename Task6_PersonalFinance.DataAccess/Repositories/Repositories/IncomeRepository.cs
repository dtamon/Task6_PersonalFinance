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
    public class IncomeRepository : IIncomeRepository
    {
        private readonly FinancesDbContext _context;

        public IncomeRepository(FinancesDbContext context)
        {
            _context = context;
        }

        public async Task CreateIncomeAsync(Income income)
        {
            await _context.Incomes.AddAsync(income);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIncomeAsync(Income income)
        {
            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Income>> GetAllIncomesAsync()
        {
            return await _context.Incomes.Include(x => x.Category).ToListAsync();
        }

        public async Task<Income?> GetIncomeByIdAsync(int id)
        {
            return await _context.Incomes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Income>> GetIncomesByCategoryIdAsync(int id)
        {
            return await _context.Incomes.Where(x => x.CategoryId == id).ToListAsync();
        }

        public async Task UpdateIncomeAsync(Income income)
        {
            _context.Incomes.Update(income);
            await _context.SaveChangesAsync();
        }
    }
}
