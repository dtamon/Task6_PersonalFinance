using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.DataAccess.Entities;

namespace Task6_PersonalFinance.DataAccess.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Task<ICollection<Expense>> GetAllExpenseAsync();
        Task<Expense?> GetExpenseByIdAsync(int id);
        Task CreateExpenseAsync(Expense outcome);
        Task UpdateExpenseAsync(Expense outcome);
        Task DeleteExpenseAsync(Expense outcome);
    }
}
