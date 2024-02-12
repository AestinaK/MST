namespace App.Expenses.Dto;

public class SearchExpensesDto
{
    public long Id { get; set; }
    public DateTime TxnDate { get; set; }
    public double Amount { get; set; }
    public string Status { get; set; }
    public string Name { get; set; }
}