using System.ComponentModel.DataAnnotations;
using App.Setup.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace api_fetch.Areas.Root.ViewModel.Income;

public class IncomeVm
{
    public string? Description { get; set; }
    public long UserId { get; set; }
    public decimal Amount{ get; set; }
    
    [Display(Name = "Source")]
    public long CategoryId { get; set; }
    public DateTime Date { get; set; }
    public List<IncomeCategory> IncomeCategories { get; set; }

    public SelectList GetIncome() => new SelectList(IncomeCategories, nameof(IncomeCategory.Id)
        , nameof(IncomeCategory.Name), CategoryId);
}