using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.DataAccess.Entities;

namespace Task6_PersonalFinance.DataAccess.Repositories.Interfaces
{
    public interface IOutcomeCategoryRepository
    {
        Task<ICollection<OutcomeCategory>> GetAllOutcomeCategoriesAsync();
        Task<OutcomeCategory?> GetOutcomeCategoryByIdAsync(int id);
        Task CreateOutcomeCategoryAsync(OutcomeCategory outcomeCategory);
        Task UpdateOutcomeCategoryAsync(OutcomeCategory outcomeCategory);
        Task DeleteOutcomeCategoryAsync(OutcomeCategory outcomeCategory);
    }
}
