using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_PersonalFinance.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<UserIncomeCategory> IncomeCategories { get; set; } = new List<UserIncomeCategory>();
        public virtual ICollection<UserExpenseCategory> ExpenseCategories { get; set; } = new List<UserExpenseCategory>();
    }
}
