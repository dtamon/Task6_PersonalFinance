using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_PersonalFinance.DataAccess.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public UserIncomeCategory Category { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
