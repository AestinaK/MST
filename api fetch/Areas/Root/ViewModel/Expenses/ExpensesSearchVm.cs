using App.Expenses.Model;
using App.Expenses.Repository;
using App.Setup.Model;

namespace api_fetch.Areas.Root.ViewModel.Expenses;

public class ExpensesSearchVm
{
    public List<IncomeCategory> IncomeCategories { get; set; }
    public List<ExpensesRecord> ExpensesCategories { get; set; }
}