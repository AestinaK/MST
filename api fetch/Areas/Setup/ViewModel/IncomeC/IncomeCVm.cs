using App.Setup.Model;

namespace api_fetch.Areas.Setup.ViewModel.IncomeC;

public class IncomeCVm
{
    public string Name { get; set; }
    public string Description { get; set; } 
    public List<IncomeCategory> Categories { get; set; }
}