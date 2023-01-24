using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.Core.Dto;

namespace Task6_PersonalFinance.Core.Services.Interfaces
{
    public interface IExpenseCategoryService
    {
        Task Add(ExpenseCategoryDto dto);
        Task<ICollection<ExpenseCategoryDto>> GetAllForUser();
        Task<ExpenseCategoryDto> GetById(int id);
        Task Remove(int id);
        Task Update(int id, ExpenseCategoryDto dto);
    }
}
