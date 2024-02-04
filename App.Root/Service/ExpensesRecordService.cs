using App.Base.DataContext.Interface;
using App.Expenses.Dto;
using App.Expenses.Model;
using App.Expenses.Service.Interface;

namespace App.Expenses.Service;

public class ExpensesRecordService : IExpensesRecordService
{
    private readonly IUow _uow;

    public ExpensesRecordService(IUow uow)
    {
        _uow = uow;
    }

    public async Task<ExpensesRecord> CreateExpensesRecord(CreateExpensesDto dto)
    {
        var expenses = new ExpensesRecord();
        expenses.ExpensesId = dto.ExpensesId;
        expenses.UserId = dto.ExpensesId;
        expenses.Amount = dto.Amount;
        expenses.TxnDate = dto.TxnDate;
        expenses.Status = dto.Status;

        await _uow.CreateAsync(expenses);
        await _uow.CommitAsync();
        return expenses;
    }
}