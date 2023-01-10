using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.DataAccess.Context;
using Task6_PersonalFinance.DataAccess.Entities;
using Task6_PersonalFinance.DataAccess.Repositories.Interfaces;

namespace Task6_PersonalFinance.DataAccess.Repositories.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FinancesDbContext _context;

        public AccountRepository(FinancesDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUserName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task RegisterUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
