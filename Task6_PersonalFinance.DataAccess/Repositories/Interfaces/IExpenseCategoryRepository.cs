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
        Task<ICollection<UserExpenseCategory>> GetAllExpenseCategoriesAsync(int userId);
        Task<UserExpenseCategory?> GetExpenseCategoryByIdAsync(int id);
        Task CreateExpenseCategoryAsync(UserExpenseCategory outcomeCategory);
        Task UpdateExpenseCategoryAsync(UserExpenseCategory outcomeCategory);
        Task DeleteExpenseCategoryAsync(UserExpenseCategory outcomeCategory);
    }
}
