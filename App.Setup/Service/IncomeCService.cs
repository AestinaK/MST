using App.Setup.Dto;
using App.Setup.Model;
using App.Setup.Service.Interface;

namespace App.Setup.Service;

public class IncomeCService : IIncomeCService
{
    public Task<IncomeCategory> CreateIncomeCategory(IncomeCDto dto)
    {
        throw new NotImplementedException();
    }
}