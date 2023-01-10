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
    public class OutcomeRepository : IOutcomeRepository
    {
        private readonly FinancesDbContext _context;

        public OutcomeRepository(FinancesDbContext context)
        {
            _context = context;
        }

        public async Task CreateOutcomeAsync(Outcome outcome)
        {
            await _context.Outcomes.AddAsync(outcome);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOutcomeAsync(Outcome outcome)
        {
            _context.Outcomes.Remove(outcome);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Outcome>> GetAllOutcomesAsync()
        {
            return await _context.Outcomes.Include(x => x.OutcomeCategory).ToListAsync();
        }

        public async Task<Outcome?> GetOutcomeByIdAsync(int id)
        {
            return await _context.Outcomes.Include(x => x.OutcomeCategory).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateOutcomeAsync(Outcome outcome)
        {
            _context.Outcomes.Update(outcome);
            await _context.SaveChangesAsync();
        }
    }
}
