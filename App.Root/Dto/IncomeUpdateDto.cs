namespace App.Expenses.Dto;

public class IncomeUpdateDto
{
    public long Id { get; set; }    
    public long UserId { get; set; }    
    public long CategoryId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
}