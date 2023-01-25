using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.Core.Dto;

namespace Task6_PersonalFinance.Core.Services.Interfaces
{
    public interface IExpenseService
    {
        Task Add(ExpenseDto dto);
        Task<ICollection<ExpenseDto>> GetAllForUser();
        Task<ICollection<ExpenseDto>> GetByCategoryId(int id);
        Task<ExpenseDto> GetByIdForUser(int id);
        Task Remove(int id);
        Task Update(ExpenseDto dto);
    }
}
