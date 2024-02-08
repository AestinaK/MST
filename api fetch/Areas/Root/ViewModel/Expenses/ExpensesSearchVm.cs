using App.Expenses.Enum;

namespace api_fetch.Areas.Root.ViewModel.Expenses;

public class ExpensesSearchVm
{
    public List<ExpensesInfoVm> ExpensesCategories { get; set; }
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