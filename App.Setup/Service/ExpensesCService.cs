using App.Base.DataContext.Interface;
using App.Setup.Dto;
using App.Setup.Model;
using App.Setup.Service.Interface;

namespace App.Setup.Service;

public class ExpensesCService : IExpensesCService
{
    private readonly IUow _uow;

    public ExpensesCService(IUow uow)
    {
        _uow = uow;
    }

    public async Task<ExpensesCategory> CreateExpenses(ExpensesCDto dto)
    {
        var category = new ExpensesCategory();
        category.Name = dto.Name;
        category.Description = dto.Description;
        await _uow.CreateAsync(category);
        await _uow.CommitAsync();
        return category;
    }
}