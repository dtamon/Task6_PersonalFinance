using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.Core.Dto;
using Task6_PersonalFinance.Core.Services.Interfaces;
using Task6_PersonalFinance.DataAccess.Context;
using Task6_PersonalFinance.DataAccess.Entities;

namespace Task6_PersonalFinance.Core.Seeder
{
    public class DataSeeder
    {
        private readonly FinancesDbContext _context;
        private IAccountService _accountService;

        public DataSeeder(FinancesDbContext financesDbContext, IAccountService accountService)
        {
            _context = financesDbContext;
            _accountService = accountService;
        }

        public void Seed()
        {
            if (!_context.Database.CanConnect())
                return;
            if (!_context.Users.Any())
            {
                _accountService.RegisterUser(new RegisterUserDto()
                {
                    UserName = "user",
                    Email = "user@user.com",
                    Password = "password",
                    ConfirmPassword = "password",
                });
            }
            if (!_context.UserExpenseCategories.Any())
            {
                _context.UserExpenseCategories.AddRange(GetExpenseCategories());
                _context.SaveChanges();
            }
            if (!_context.Expenses.Any())
            {
                _context.Expenses.AddRange(GetExpenses());
                _context.SaveChanges();
            }
            if (!_context.UserIncomeCategories.Any())
            {
                _context.UserIncomeCategories.AddRange(GetIncomeCategories());
                _context.SaveChanges();
            }
            if (!_context.Incomes.Any())
            {
                _context.Incomes.AddRange(GetIncomes());
                _context.SaveChanges();
            }
        }

        private IEnumerable<UserExpenseCategory> GetExpenseCategories()
        {
            return new List<UserExpenseCategory>()
            {
                new UserExpenseCategory() {Name = "Food", UserId = 1 },
                new UserExpenseCategory() {Name = "Gym", UserId = 1 },
                new UserExpenseCategory() {Name = "Fishing", UserId = 1 },
            };
        }
        private IEnumerable<Expense> GetExpenses()
        {
            return new List<Expense>()
            {
                new Expense() {CategoryId = 1, Amount = 35.00, Comment = "weekly groceries", Date = new DateTime(2022, 12, 1, 00, 00, 00)},
                new Expense() {CategoryId = 1, Amount = 25.00, Comment = "weekly groceries", Date = new DateTime(2022, 12, 8, 00, 00, 00)},
                new Expense() {CategoryId = 1, Amount = 35.00, Comment = "weekly groceries", Date = new DateTime(2022, 12, 15,  00, 00, 00)},
                new Expense() {CategoryId = 2, Amount = 65.00, Comment = "monthly carnet fee", Date = new DateTime(2022, 12, 1, 00, 00, 00)},
                new Expense() {CategoryId = 2, Amount = 65.00, Comment = "monthly carnet fee", Date = new DateTime(2023, 1, 1,  00, 00, 00)},
                new Expense() {CategoryId = 2, Amount = 65.00, Comment = "monthly carnet fee", Date = new DateTime(2023, 2, 1, 00, 00, 00)},
                new Expense() {CategoryId = 3, Amount = 20.00, Comment = "spinning baits", Date = new DateTime(2022, 12, 6,  00, 00, 00)},
                new Expense() {CategoryId = 3, Amount = 35.00, Comment = "new fishing line", Date = new DateTime(2023, 1, 15,  00, 00, 00)},
                new Expense() {CategoryId = 3, Amount = 12.00, Comment = "groundbaits", Date = new DateTime(2023, 1, 20, 17, 00, 00)},
            };
        }
        private IEnumerable<UserIncomeCategory> GetIncomeCategories()
        {
            return new List<UserIncomeCategory>()
            {
                new UserIncomeCategory() {Name = "Salary", UserId = 1},
                new UserIncomeCategory() {Name = "Allegro", UserId = 1},
            };
        }
        private IEnumerable<Income> GetIncomes()
        {
            return new List<Income>()
            {
                new Income() { CategoryId = 1, Amount = 4500, Comment = "monthly payment", Date = new DateTime(2022, 11, 4, 00, 00, 00)},
                new Income() { CategoryId = 1, Amount = 4500, Comment = "monthly payment", Date = new DateTime(2022, 12, 4, 00, 00, 00)},
                new Income() { CategoryId = 1, Amount = 4500, Comment = "monthly payment", Date = new DateTime(2022, 01, 4, 00, 00, 00)},
                new Income() { CategoryId = 2, Amount = 500, Comment = "selling PS3 console", Date = new DateTime(2022, 12, 18, 15, 30, 00)},
                new Income() { CategoryId = 2, Amount = 1200, Comment = "selling old graphic card", Date = new DateTime(2022, 12,20, 12, 35, 00)},
            };
        }


    }
}
