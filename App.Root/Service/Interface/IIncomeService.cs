using App.Expenses.Dto;
using App.Expenses.Model;

namespace App.Expenses.Service.Interface;

public interface IIncomeService
{
    Task<IncomeRecord> Create(IncomeDto dto);
}