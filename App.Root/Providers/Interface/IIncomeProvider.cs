using App.Expenses.Dto;

namespace App.Expenses.Providers.Interface;

public interface IIncomeProvider
{
    Task<List<SearchIncomeDto>> GetIncomeList(DateTime date);
}