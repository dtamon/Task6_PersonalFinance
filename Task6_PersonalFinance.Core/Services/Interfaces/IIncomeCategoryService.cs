using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.Core.Dto;
using Task6_PersonalFinance.DataAccess.Queries;

namespace Task6_PersonalFinance.Core.Services.Interfaces
{
    public interface IIncomeCategoryService
    {
        Task Add(IncomeCategoryDto dto);
        Task<ICollection<IncomeCategoryDto>> GetAllForUser(SearchQuery query);
        Task<IncomeCategoryDto> GetById(int id);
        Task Remove(int id);
        Task Update(int id, IncomeCategoryDto dto);
    }
}
