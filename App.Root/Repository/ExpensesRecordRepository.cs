using App.Base.GenericRepository;
using App.Expenses.Model;
using App.Expenses.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace App.Expenses.Repository;

public class ExpensesRecordRepository : GenericRepository<ExpensesRecord>, IExpensesRecordRepository
{
    public ExpensesRecordRepository(DbContext context) : base(context){}
}