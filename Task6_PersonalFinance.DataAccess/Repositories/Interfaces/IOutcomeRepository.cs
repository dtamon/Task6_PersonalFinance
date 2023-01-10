using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.DataAccess.Entities;

namespace Task6_PersonalFinance.DataAccess.Repositories.Interfaces
{
    public interface IOutcomeRepository
    {
        Task<ICollection<Outcome>> GetAllOutcomesAsync();
        Task<Outcome?> GetOutcomeByIdAsync(int id);
        Task CreateOutcomeAsync(Outcome outcome);
        Task UpdateOutcomeAsync(Outcome outcome);
        Task DeleteOutcomeAsync(Outcome outcome);
    }
}
