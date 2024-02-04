using System.ComponentModel.DataAnnotations.Schema;
using App.Base.Constants;
using App.Base.GenericModel;

namespace App.Setup.Model;

[Table("expenses_category", Schema = SchemaConstants.Setup)]
public class ExpensesCategory : GenericModel
{
    public string Name { get; set; }
    public string? Description { get; set; }
}