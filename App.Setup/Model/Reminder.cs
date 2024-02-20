using System.ComponentModel.DataAnnotations.Schema;
using App.Base.Constants;
using App.Base.GenericModel;

namespace App.Setup.Model;

[Table("reminder",Schema = SchemaConstants.Setup)]
public class Reminder : GenericModel
{
    public DateTime DueDate { get; set; }
    public virtual ExpensesCategory? Category { get; set; }
    public long? CategoryId { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}