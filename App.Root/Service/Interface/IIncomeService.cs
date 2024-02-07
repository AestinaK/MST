using App.Expenses.Model;

namespace App.Expenses.Service.Interface;

public interface IIncomeService
{
    Task<IncomeRecord> Create();
}