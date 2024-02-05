using App.Expenses.Enum;
using App.Setup.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace api_fetch.Areas.Root.ViewModel.Expenses;

public class ExpensesVm
{
    public string? Description { get; set; }
    public Decimal Amount { get; set; }
    public long Expenses { get; set; }
    public PaymentStatus  Status { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
    public long UserId { get; set; }
    
    public List<ExpensesCategory> Categories { get; set; }

    public SelectList GetCategories() =>
        new SelectList(Categories, nameof(ExpensesCategory.Id), nameof(ExpensesCategory.Name));

}