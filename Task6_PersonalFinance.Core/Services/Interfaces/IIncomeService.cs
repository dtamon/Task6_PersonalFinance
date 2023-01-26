using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.Core.Dto;

namespace Task6_PersonalFinance.Core.Services.Interfaces
{
    public interface IIncomeService
    {
        Task Add(IncomeDto dto);
        Task<ICollection<IncomeDto>> GetAllForUser();
        Task<ICollection<IncomeDto>> GetByCategoryId(int id);
        Task<IncomeDto> GetByIdForUser(int id);
        Task Remove(int id);
        Task Update(int id, IncomeDto dto);
    }
}
