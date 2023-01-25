using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.DataAccess.Entities;

namespace Task6_PersonalFinance.DataAccess.Repositories.Interfaces
{
    public interface IIncomeRepository
    {
        Task<ICollection<Income>> GetAllIncomesAsync();
        Task<ICollection<Income>> GetIncomesByCategoryIdAsync(int id);
        Task<Income?> GetIncomeByIdAsync(int id);
        Task CreateIncomeAsync(Income income);
        Task UpdateIncomeAsync(Income income);
        Task DeleteIncomeAsync(Income income);
    }
}
