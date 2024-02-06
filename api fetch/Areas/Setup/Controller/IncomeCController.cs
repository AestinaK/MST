using api_fetch.Areas.Setup.ViewModel.IncomeC;
using App.Setup.Dto;
using App.Setup.Service.Interface;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Setup.Controller;

[Area("setup")]
public class IncomeCController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IIncomeCService _incomeCService;
    private readonly INotyfService _notyfService;

    public IncomeCController(IIncomeCService incomeCService,
        INotyfService notyfService)
    {
        _incomeCService = incomeCService;
        _notyfService = notyfService;
    }

    [HttpGet]
    // GET
    public IActionResult Add()
    {
        var vm = new IncomeCVm();
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Add(IncomeCVm vm)
    {
        try
        {
            var dto = new IncomeCDto()
            {
                Name = vm.Name,
                Description = vm.Description
            };
            await _incomeCService.CreateIncomeCategory(dto);
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