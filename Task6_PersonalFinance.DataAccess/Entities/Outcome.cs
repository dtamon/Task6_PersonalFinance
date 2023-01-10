using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_PersonalFinance.DataAccess.Entities
{
    public class Outcome
    {
        public int Id { get; set; }
        public int OutcomeCategoryId { get; set; }
        public OutcomeCategory OutcomeCategory { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
    }
}
