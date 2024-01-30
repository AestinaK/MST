using System.ComponentModel.DataAnnotations;

namespace api_fetch.Areas.Setup.ViewModel;

public class EmployeeVm
{
    [Display(Name = "Employee Name")]
    public string Name { get; set; }
    
    [Display(Name = "Employee Address")]
    public string Address { get; set; }
    
    [Display(Name="Contact")]
    public string Contact { get; set; }

    public long RoleId { get; set; }
}