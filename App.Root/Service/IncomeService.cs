using App.Expenses.Dto;
using App.Expenses.Model;
using App.Expenses.Service.Interface;

namespace App.Expenses.Service;

public class IncomeService : IIncomeService
{
    public Task<IncomeRecord> Create(IncomeDto dto)
    {
        throw new NotImplementedException();
    }
}