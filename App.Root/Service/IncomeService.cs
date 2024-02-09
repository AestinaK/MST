using App.Base.DataContext.Interface;
using App.Expenses.Dto;
using App.Expenses.Model;
using App.Expenses.Repository.Interface;
using App.Expenses.Service.Interface;

namespace App.Expenses.Service;

public class IncomeService : IIncomeService
{
    private readonly IUow _uow;
    private readonly IIncomeRecordRepository _incomeRecordRepo;

    public IncomeService(IUow uow,
        IIncomeRecordRepository incomeRecordRepo)
    {
        _uow = uow;
        _incomeRecordRepo = incomeRecordRepo;
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

    public async Task<IncomeRecord> Delete(long id)
    {
        var data = await _incomeRecordRepo.FindAsync(id);
        _uow.Remove(data);
        await _uow.CommitAsync();
        return data;
    }

    public async Task<IncomeRecord> Update(IncomeUpdateDto dto)
    {
        var data = await _incomeRecordRepo.FindAsync(dto.Id);
        data.Amount = dto.Amount;
        data.Description = dto.Description;
        data.CategoryId = dto.CategoryId;
        data.Date = dto.Date;
        _uow.Update(data);
        await _uow.CommitAsync();
        return data;
    }
}