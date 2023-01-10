using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_PersonalFinance.DataAccess.Entities
{
    public class IncomeCategory
    {
        public int Id { get; set; }
        public string IncomeCategoryName { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
    }
}
