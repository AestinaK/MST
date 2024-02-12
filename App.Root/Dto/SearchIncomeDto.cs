namespace App.Expenses.Dto;

public class SearchIncomeDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public  string Name { get; set; }
}