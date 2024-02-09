using App.Expenses.Dto;
using App.Expenses.Model;

namespace App.Expenses.Service.Interface;

public interface IExpensesRecordService
{
    Task<ExpensesRecord> CreateExpensesRecord(CreateExpensesDto dto);
    Task<ExpensesRecord> Delete(long id);
    Task<ExpensesRecord> Update(ExpUpdateDto dto);
}