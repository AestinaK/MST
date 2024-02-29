namespace api_fetch.ViewModel;

public class IndexDataVm
{
    public decimal TotalIncome { get; set; }
    public decimal TotalExpenses { get; set; }
    public List<ReminderVm> Reminders { get; set; }
}

public class ReminderVm
{
    public long Id    { get; set; }
    public string  Name { get; set; }
    public DateTime Date { get; set; }
    public long DueDays { get; set; }
}