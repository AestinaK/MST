using System.Data;
using App.Setup.Dto;
using App.Setup.Exceptions;
using App.Setup.Repository.Interface;
using App.Setup.Validators.Interface;

namespace App.Setup.Validators;

public class CategoryValidator : ICategoryValidator
{
    private readonly IIncomeCRepository _incomeCRepo;
    private readonly IExpensesCRepository _expensesCRepo;

    public CategoryValidator(IIncomeCRepository incomeCRepo,
        IExpensesCRepository expensesCRepo)
    {
        _incomeCRepo = incomeCRepo;
        _expensesCRepo = expensesCRepo;
    }

    public async Task IncomeCValidator(IncomeCDto dto)
    {
        bool exist = await _incomeCRepo.CheckIfExistAsync(x => x.Name == dto.Name);
        if (exist)
        {
            throw new DataExistException();
        }
    }
    public async Task ExpensesCValidator(ExpensesCDto dto)
    {
        bool exist = await _expensesCRepo.CheckIfExistAsync(x => x.Name == dto.Name);
        if (exist)
        {
            throw new DataExistException();
        }
    }
}