using App.Base.DataContext.Interface;
using App.Expenses.Dto;
using App.Expenses.Model;
using App.Expenses.Repository.Interface;
using App.Expenses.Service.Interface;

namespace App.Expenses.Service;

public class ExpensesRecordService : IExpensesRecordService
{
    private readonly IUow _uow;
    private readonly IExpensesRecordRepository _expensesRecordRepo;

    public ExpensesRecordService(IUow uow,
        IExpensesRecordRepository expensesRecordRepo)
    {
        _uow = uow;
        _expensesRecordRepo = expensesRecordRepo;
    }

    public async Task<ExpensesRecord> CreateExpensesRecord(CreateExpensesDto dto)
    {
        var expenses = new ExpensesRecord();
        expenses.ExpensesId = dto.ExpensesId;
        expenses.UserId = dto.UserId;
        expenses.Amount = dto.Amount;
        expenses.TxnDate = dto.TxnDate;
        expenses.Status = dto.Status;

        await _uow.CreateAsync(expenses);
        await _uow.CommitAsync();
        return expenses;
    }

    public async Task<ExpensesRecord> Delete(long id)
    {
        var data = await _expensesRecordRepo.FindAsync(id);
        _uow.Remove(data);
        await _uow.CommitAsync();
        return data;
    }

    public async Task<ExpensesRecord> Update(ExpUpdateDto dto)
    {
        var data = await _expensesRecordRepo.FindAsync(dto.Id);
        data.ExpensesId = dto.ExpensesId;
        data.Amount = dto.Amount;
        data.TxnDate = dto.TxnDate;
        data.Description = dto.Descrption;
        data.Status = dto.Status;
        _uow.Update(data);
        await _uow.CommitAsync();
        return data;
    }
}