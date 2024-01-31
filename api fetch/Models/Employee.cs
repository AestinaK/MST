using App.Base.GenericModel;

namespace api_fetch.Models;

public class Employee :GenericModel
{
    public virtual Roles Roles { get; set; }
    public long RoleId { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public string Contact { get; set; }
}