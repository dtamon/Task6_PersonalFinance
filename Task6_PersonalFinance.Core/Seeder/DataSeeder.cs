using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.Core.Services.Interfaces;
using Task6_PersonalFinance.DataAccess.Context;

namespace Task6_PersonalFinance.Core.Seeder
{
    public class DataSeeder
    {
        private readonly FinancesDbContext _financesDbContext;
        private IAccountService _accountService;

        public DataSeeder(FinancesDbContext financesDbContext, IAccountService accountService)
        {
            _financesDbContext = financesDbContext;
            _accountService = accountService;
        }

        public async Task SeedAsync()
        {
            if (!_financesDbContext.Database.CanConnect())
                return;
            // cd inc
        }
    }
}
