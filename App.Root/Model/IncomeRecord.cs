using System.ComponentModel.DataAnnotations.Schema;
using App.Base.Constants;
using App.Base.GenericModel;
using App.Setup.Model;

namespace App.Expenses.Model;

[Table("income_record",Schema = SchemaConstants.Root)]
public class IncomeRecord :GenericModel
{
    public virtual User.Model.User User { get; set; }
    public long UserId { get; set; }    
    public virtual IncomeCategory Category { get; set; }
    public long CategoryId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
}