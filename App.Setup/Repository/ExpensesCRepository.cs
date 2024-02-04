using App.Base.GenericRepository;
using App.Setup.Model;
using App.Setup.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace App.Setup.Repository;

public class ExpensesCRepository : GenericRepository<ExpensesCategory>, IExpensesCRepository
{
    public ExpensesCRepository(DbContext context) : base(context){}
}