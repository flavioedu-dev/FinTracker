﻿using FinTracker.Domain.Entities;
using FinTracker.Domain.Interfaces;
using FinTracker.Infrastructure.Database;

namespace FinTracker.Infrastructure.Repositories;

public class FinanceRepository : Repository<Finance>, IFinanceRepository
{
    public FinanceRepository(AppDbContext context) : base(context)
    {

    }
}