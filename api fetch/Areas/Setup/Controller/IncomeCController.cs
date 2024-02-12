using api_fetch.Areas.Setup.ViewModel.IncomeC;
using App.Setup.Dto;
using App.Setup.Repository.Interface;
using App.Setup.Service.Interface;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Setup.Controller;

[Area("setup")]
public class IncomeCController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IIncomeCService _incomeCService;
    private readonly INotyfService _notyfService;
    private readonly IIncomeCRepository _incomeCRepo;

    public IncomeCController(IIncomeCService incomeCService,
        INotyfService notyfService,
        IIncomeCRepository incomeCRepo)
    {
        _incomeCService = incomeCService;
        _notyfService = notyfService;
        _incomeCRepo = incomeCRepo;
    }
    
    [HttpGet]
    // GET
    public async Task<IActionResult> Add()
    {
        var vm = new IncomeCVm();
        vm.Categories = await _incomeCRepo.GetAllAsync();
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
    
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _incomeCService.Delete(id);
            _notyfService.Success("Deleted!");
        }
        catch (Exception e)
        {
           _notyfService.Error(e.Message);
           return Redirect("/");
        }
    
        return RedirectToAction(nameof(Add));
    }
}