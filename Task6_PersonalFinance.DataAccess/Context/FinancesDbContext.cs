using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.DataAccess.Entities;

namespace Task6_PersonalFinance.DataAccess.Context
{
    public class FinancesDbContext : DbContext
    {
        public FinancesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<OutcomeCategory> OutcomeCategories { get; set; }
    }
}
