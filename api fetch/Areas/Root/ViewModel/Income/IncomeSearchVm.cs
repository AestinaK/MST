using System.ComponentModel.DataAnnotations;
using api_fetch.ViewModel;
using App.Base.ValueObject;

namespace api_fetch.Areas.Root.ViewModel.Income;

public class IncomeSearchVm :BaseFilterVm
{
    [Display(Name = "Date")]
    public DateTime Date { get; set; }
    public PagedResult<IncomeInfo> Incomes { get; set; }
}

public class IncomeInfo
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Source { get; set; }
    
}