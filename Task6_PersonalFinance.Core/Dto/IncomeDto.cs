using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_PersonalFinance.Core.Dto
{
    public class IncomeDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CategoryName { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
    }
}
