﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.DataAccess.Entities;

namespace Task6_PersonalFinance.DataAccess.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Task<ICollection<Expense>> GetAllOutcomesAsync();
        Task<Expense?> GetOutcomeByIdAsync(int id);
        Task CreateOutcomeAsync(Expense outcome);
        Task UpdateOutcomeAsync(Expense outcome);
        Task DeleteOutcomeAsync(Expense outcome);
    }
}
