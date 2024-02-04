using App.Base.DataContext.Interface;
using App.Setup.Dto;
using App.Setup.Model;
using App.Setup.Service.Interface;

namespace App.Setup.Service;

public class IncomeCService : IIncomeCService
{
    private readonly IUow _uow;

    public IncomeCService(IUow uow)
    {
        _uow = uow;
    }

    public async Task<IncomeCategory> CreateIncomeCategory(IncomeCDto dto)
    {
        var income = new IncomeCategory();
        income.Name = dto.Name;
        income.Description = dto.Description;

        await _uow.CreateAsync(income);
         await _uow.CommitAsync();
         return income;
    }
}