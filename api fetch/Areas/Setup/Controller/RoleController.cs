using api_fetch.Areas.Setup.ViewModel;
using api_fetch.Data;
using api_fetch.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Setup.Controller;

[Area("Setup")]
public class RoleController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ApplicationDbContext _context;
    private readonly INotyfService _notyfService;

    public RoleController(ApplicationDbContext context,
        INotyfService notyfService)
    {
        _context = context;
        _notyfService = notyfService;
    }

    [HttpGet]
    public IActionResult Index(RoleVm vm)
    {
        vm.RolesList = _context.roles.ToList();
        return View(vm);
    }
    [HttpGet]
    public IActionResult Add()
    {
        var vm = new RoleVm();
        return View(vm);
    }

    [HttpPost]
    public IActionResult Add(RoleVm vm)
    {
        try
        {
            var role = new Roles()
            {
                Name = vm.Name,
                Description = vm.Description
            };
            _context.roles.Add(role);
            _context.SaveChanges();
			_notyfService.Success("Added");
		}
        catch (Exception e)
        {
            _notyfService.Error(e.Message);
            return Redirect("/");
        }
        return RedirectToAction(nameof(Index));

    }
    
}