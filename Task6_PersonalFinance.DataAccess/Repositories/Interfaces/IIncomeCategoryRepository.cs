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
        Task<ICollection<UserIncomeCategory>> GetAllIncomeCategoriesAsync(int userId);
        Task<UserIncomeCategory?> GetIncomeCategoryByIdAsync(int id);
        Task CreateIncomeCategoryAsync(UserIncomeCategory incomeCategory);
        Task UpdateIncomeCategoryAsync(UserIncomeCategory incomeCategory);
        Task DeleteIncomeCategoryAsync(UserIncomeCategory incomeCategory);
    }
}
