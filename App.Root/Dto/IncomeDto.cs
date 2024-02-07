namespace App.Expenses.Dto;

public class IncomeDto
{
    public long UserId { get; set; }    
    public long CategoryId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
}