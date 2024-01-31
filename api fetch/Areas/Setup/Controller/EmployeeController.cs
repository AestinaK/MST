using api_fetch.Areas.Setup.ViewModel;
using api_fetch.Data;
using api_fetch.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Setup.Controller;

[Area("Setup")]
public class EmployeeController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ApplicationDbContext _context;
    private readonly INotyfService _notyfService;

    public EmployeeController(ApplicationDbContext context,
        INotyfService notyfService)
    {
        _context = context;
        _notyfService = notyfService;
    }

    // GET
    [HttpGet]
    public IActionResult Add()
    {
        var vm = new EmployeeVm();
        return View(vm);
    }

    [HttpPost]
    public IActionResult Add(EmployeeVm vm)
    {
        try
        {
            var employee = new Employee()
            {
                Name = vm.Name,
                Adress = vm.Address,
                Contact = vm.Contact,
                RoleId = vm.RoleId
            };

            _context.employees.Add(employee);
            _context.SaveChanges();
			_notyfService.Success("Added");
		}
        catch (Exception e)
        {
            _notyfService.Error(e.Message);
            return Redirect("/");
        }
        return RedirectToAction(nameof(Add));
    }
}