using System.ComponentModel.DataAnnotations;
using api_fetch.Models;

namespace api_fetch.Areas.Setup.ViewModel;

public class RoleVm
{
    [Display(Name = "Name")]
    public string Name { get; set; }
    [Display(Name = "Description")]
    public string Description { get; set; } 
    
    public List<Roles> RolesList { get; set; }
}