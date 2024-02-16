using api_fetch.ViewModel;
using App.Expenses.Dto;
using App.Expenses.Enum;

namespace api_fetch.Areas.Root.ViewModel.Expenses;

public class ExpensesSearchVm : BaseFilterVm
{
   // public PagedResult<ExpensesInfoVm> ExpensesCategories { get; set; }
   public List<SearchExpensesDto> Categories { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}

public class ExpensesInfoVm
{
    public long Id { get; set; }
    public string Category { get; set; }
    public PaymentStatus Status { get; set; }
    public decimal Amount { get; set; }
    public DateTime  Date { get; set; } 
    
}