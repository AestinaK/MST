using App.Setup.Dto;

namespace App.Setup.Validators.Interface;

public interface ICategoryValidator
{
    Task IncomeCValidator(IncomeCDto dto);
    Task ExpensesCValidator(ExpensesCDto dto);
}