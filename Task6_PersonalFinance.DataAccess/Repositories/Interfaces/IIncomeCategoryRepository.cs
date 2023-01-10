using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.DataAccess.Entities;

namespace Task6_PersonalFinance.DataAccess.Repositories.Interfaces
{
    public interface IIncomeCategoryRepository
    {
        Task<ICollection<IncomeCategory>> GetAllIncomeCategoriesAsync();
        Task<IncomeCategory?> GetIncomeCategoryByIdAsync(int id);
        Task CreateIncomeCategoryAsync(IncomeCategory incomeCategory);
        Task UpdateIncomeCategoryAsync(IncomeCategory incomeCategory);
        Task DeleteIncomeCategoryAsync(IncomeCategory incomeCategory);
    }
}
