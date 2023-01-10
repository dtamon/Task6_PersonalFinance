using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.DataAccess.Entities;

namespace Task6_PersonalFinance.DataAccess.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<User?> GetUserByUserName(string username);
        Task RegisterUser(User user);
    }
}
