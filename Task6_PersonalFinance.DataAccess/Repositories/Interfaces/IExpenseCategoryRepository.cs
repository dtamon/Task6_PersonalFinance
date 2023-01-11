using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.DataAccess.Entities;

namespace Task6_PersonalFinance.DataAccess.Repositories.Interfaces
{
    public interface IExpenseCategoryRepository
    {
        Task<ICollection<UserExpenseCategory>> GetAllOutcomeCategoriesAsync();
        Task<UserExpenseCategory?> GetOutcomeCategoryByIdAsync(int id);
        Task CreateOutcomeCategoryAsync(UserExpenseCategory outcomeCategory);
        Task UpdateOutcomeCategoryAsync(UserExpenseCategory outcomeCategory);
        Task DeleteOutcomeCategoryAsync(UserExpenseCategory outcomeCategory);
    }
}
