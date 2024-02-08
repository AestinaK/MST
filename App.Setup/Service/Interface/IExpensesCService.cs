using App.Setup.Dto;
using App.Setup.Model;

namespace App.Setup.Service.Interface;

public interface IExpensesCService
{
    Task<ExpensesCategory> CreateExpenses(ExpensesCDto dto);
    Task<ExpensesCategory> Delete(long id);
}