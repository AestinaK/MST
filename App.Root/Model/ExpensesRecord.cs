using System.ComponentModel.DataAnnotations.Schema;
using App.Base.Constants;
using App.Base.GenericModel;
using App.Expenses.Enum;
using App.Setup.Model;

namespace App.Expenses.Model;

[Table("Expenses_Record",Schema = SchemaConstants.Root)]
public class ExpensesRecord : GenericModel
{
    public virtual User.Model.User User { get; set; }
    public long UserId { get; set; }
    public DateTime TxnDate { get; set; }
    public decimal  Amount { get; set; }
    public virtual  ExpensesCategory Expenses { get; set; }
    public long ExpensesId{get; set; }
    public PaymentStatus  Status { get; set; }
    public string? Description { get; set; } 
}