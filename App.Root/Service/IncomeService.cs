using App.Setup.Dto;
using App.Setup.Model;
using App.Setup.Service.Interface;

namespace App.Expenses.Service;

public class IncomeService : IIncomeCService
{
    public Task<IncomeCategory> CreateIncomeCategory(IncomeCDto dto)
    {
        throw new NotImplementedException();
    }
}