namespace api_fetch.Areas.Root.ViewModel.Income;

public class IncomeVm
{
    public string? Description { get; set; }
    public long UserId { get; set; }
    public decimal Amount{ get; set; }
    public long Source { get; set; }
    public DateTime Date { get; set; }
}