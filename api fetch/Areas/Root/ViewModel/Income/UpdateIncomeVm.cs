using App.Setup.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace api_fetch.Areas.Root.ViewModel.Income;

public class UpdateIncomeVm
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public long CategoryId { get; set; }
    public string? Description { get; set; }
    public List<IncomeCategory> IncomeCategories { get; set; }

    public SelectList GetIncome() => new SelectList(IncomeCategories, nameof(IncomeCategory.Id)
        , nameof(IncomeCategory.Name), CategoryId);
}