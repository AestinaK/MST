using App.Base.DataContext.Interface;
using App.Setup.Dto;
using App.Setup.Model;
using App.Setup.Repository.Interface;
using App.Setup.Service.Interface;

namespace App.Setup.Service;

public class ExpensesCService : IExpensesCService
{
    private readonly IUow _uow;
    private readonly IExpensesCRepository _expensesCRepo;

    public ExpensesCService(IUow uow,
        IExpensesCRepository expensesCRepo)
    {
        _uow = uow;
        _expensesCRepo = expensesCRepo;
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

    public async Task<ExpensesCategory> Delete(long id)
    {
        var data=await _expensesCRepo.FindAsync(id);
        _uow.Remove(data);
        await _uow.CommitAsync();
        return data;
    }
}