using App.Expenses.Enum;

namespace App.Expenses.Dto;

public class CreateExpensesDto
{
    public long UserId { get; set; }
    public DateTime TxnDate { get; set; }
    public decimal  Amount { get; set; }
    public long ExpensesId{get; set; }
    public PaymentStatus  Status { get; set; }
    public string? Descrption { get; set; }
}