using App.Base.GenericRepository;
using App.Expenses.Model;
using App.Expenses.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace App.Expenses.Repository;

public class IncomeRecordRepository : GenericRepository<IncomeRecord> ,IIncomeRecordRepository
{
    public IncomeRecordRepository(DbContext context) : base(context)
    {
        
    }
}