using App.Base.Dropdown;

namespace App.Setup.Provider.Interface;

public interface IExpensesCategoryProvider
{
    Task<List<DropdownDto>> GetCategoryAsync();
}