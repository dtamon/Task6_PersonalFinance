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
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly FinancesDbContext _context;

        public ExpenseRepository(FinancesDbContext context)
        {
            _context = context;
        }

        public async Task CreateOutcomeAsync(Expense outcome)
        {
            await _context.Expenses.AddAsync(outcome);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOutcomeAsync(Expense outcome)
        {
            _context.Expenses.Remove(outcome);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Expense>> GetAllOutcomesAsync()
        {
            return await _context.Expenses.Include(x => x.Category).ToListAsync();
        }

        public async Task<Expense?> GetOutcomeByIdAsync(int id)
        {
            return await _context.Expenses.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateOutcomeAsync(Expense outcome)
        {
            _context.Expenses.Update(outcome);
            await _context.SaveChangesAsync();
        }
    }
}
