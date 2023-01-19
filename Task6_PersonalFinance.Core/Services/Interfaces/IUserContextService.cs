using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Task6_PersonalFinance.Core.Services.Interfaces
{
    public interface IUserContextService
    {
        ClaimsPrincipal? User { get; }
        int? GetUserId { get; }
    }
}
