using App.Expenses.Dto;
using App.Expenses.Model;

namespace App.Expenses.Service.Interface;

public interface IIncomeService
{
    Task<IncomeRecord> Create(IncomeDto dto);
    Task<IncomeRecord> Delete(long id);

    Task<IncomeRecord> Update(IncomeUpdateDto dto);
}