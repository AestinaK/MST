using App.Base.GenericRepository;
using App.Setup.Model;
using App.Setup.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace App.Setup.Repository;

public class IncomeCRepository : GenericRepository<IncomeCategory>, IIncomeCRepository
{
    public IncomeCRepository(DbContext context) : base(context){}
}