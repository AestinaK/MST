using App.Base.DataContext.Interface;
using App.Setup.Dto;
using App.Setup.Model;
using App.Setup.Repository.Interface;
using App.Setup.Service.Interface;
using App.Setup.Validators.Interface;

namespace App.Setup.Service;

public class IncomeCService : IIncomeCService
{
    private readonly IUow _uow;
    private readonly IIncomeCRepository _incomeCRepo;
    private readonly ICategoryValidator _categoryValidator;

    public IncomeCService(IUow uow,
        IIncomeCRepository incomeCRepo,
        ICategoryValidator categoryValidator)
    {
        _uow = uow;
        _incomeCRepo = incomeCRepo;
        _categoryValidator = categoryValidator;
    }

    public async Task<IncomeCategory> CreateIncomeCategory(IncomeCDto dto)
    {
        await _categoryValidator.IncomeCValidator(dto);
        var income = new IncomeCategory();
        income.Name = dto.Name;
        income.Description = dto.Description;

        await _uow.CreateAsync(income);
        await _uow.CommitAsync();
        return income;
    }

    public async Task<IncomeCategory> Delete(long id)
    {
        var data = await _incomeCRepo.FindAsync(id);
         _uow.Remove(data);
         await _uow.CommitAsync();
         return data;
    }
}