using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_PersonalFinance.DataAccess.Entities
{
    public class OutcomeCategory
    {
        public int Id { get; set; }
        public string OutcomeCategoryName { get; set; }
        public virtual ICollection<Outcome> Outcomes { get; set; }
    }
}
