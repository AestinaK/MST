using App.Expenses.Dto;

namespace App.Expenses.Providers.Interface;

public interface IExpensesProvider
{
    Task <List<SearchExpensesDto>> GetExpensesList(DateTime date);
}