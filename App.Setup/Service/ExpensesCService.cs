using App.Base.DataContext.Interface;
using App.Setup.Dto;
using App.Setup.Model;
using App.Setup.Repository.Interface;
using App.Setup.Service.Interface;
using App.Setup.Validators.Interface;

namespace App.Setup.Service;

public class ExpensesCService : IExpensesCService
{
    private readonly IUow _uow;
    private readonly IExpensesCRepository _expensesCRepo;
    private readonly ICategoryValidator _categoryValidator;

    public ExpensesCService(IUow uow,
        IExpensesCRepository expensesCRepo,
        ICategoryValidator categoryValidator)
    {
        _uow = uow;
        _expensesCRepo = expensesCRepo;
        _categoryValidator = categoryValidator;
    }

    public async Task<ExpensesCategory> CreateExpenses(ExpensesCDto dto)
    {
        await _categoryValidator.ExpensesCValidator(dto);
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