using App.Base.DataContext.Interface;
using App.Expenses.Dto;
using App.Expenses.Model;
using App.Expenses.Service.Interface;

namespace App.Expenses.Service;

public class IncomeService : IIncomeService
{
    private readonly IUow _uow;
    public IncomeService(IUow uow)
    {
        _uow = uow;
    }
    public async Task<IncomeRecord> Create(IncomeDto dto)
    {
        var income = new IncomeRecord();
        income.UserId = dto.UserId;
        income.CategoryId = dto.CategoryId;
        income.Amount = dto.Amount;
        income.Description = dto.Description;
        income.Date = dto.Date;
        await _uow.CreateAsync(income);
        await _uow.CommitAsync();
        return income;
    }
}