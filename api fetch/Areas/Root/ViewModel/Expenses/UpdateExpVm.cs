using App.Expenses.Enum;
using App.Setup.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace api_fetch.Areas.Root.ViewModel.Expenses;

public class UpdateExpVm
{
    public long Id { get; set; }
    public long ExpensesId { get; set; }
    public PaymentStatus Status { get; set; }
    public decimal Amount { get; set; }
    public DateTime  Date { get; set; }
    public string? Description { get; set; }
    public List<ExpensesCategory> Categories { get; set; }

    public SelectList GetCategories() =>
        new SelectList(Categories, nameof(ExpensesCategory.Id), nameof(ExpensesCategory.Name));
}