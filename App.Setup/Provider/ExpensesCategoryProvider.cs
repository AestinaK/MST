using App.Base.Constants;
using App.Base.Dropdown;
using App.Setup.Provider.Interface;
using App.Setup.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace App.Setup.Provider;

public class ExpensesCategoryProvider : IExpensesCategoryProvider
{
    private readonly IExpensesCRepository _expensesCRepo;

    public ExpensesCategoryProvider(IExpensesCRepository expensesCRepo)
    {
        _expensesCRepo = expensesCRepo;
    }
    
   
    public async Task<List<DropdownDto>> GetCategoryAsync()
    {
        return await _expensesCRepo.GetQueryable().Where(x=>x.RecStatus == Status.Active)
            .Select(x=>new DropdownDto()
            {
                Id = x.Id,
                Name=x.Name
            }).ToListAsync();
    }
}