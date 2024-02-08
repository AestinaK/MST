using App.Setup.Model;

namespace api_fetch.Areas.Setup.ViewModel.ExpensesC;

public class ExpensesCVm
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<ExpensesCategory> Categories { get; set; }
}