using api_fetch.Areas.Setup.ViewModel.ExpensesC;
using App.Setup.Dto;
using App.Setup.Repository.Interface;
using App.Setup.Service.Interface;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Setup.Controller;

[Area("setup")]
public class ExpensesCController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IExpensesCService _expensesCService;
    private readonly INotyfService _notyfService;
    private readonly IExpensesCRepository _expensesCRepo;

    public ExpensesCController(IExpensesCService expensesCService,
        INotyfService notyfService,
        IExpensesCRepository expensesCRepo)
    {
        _expensesCService = expensesCService;
        _notyfService = notyfService;
        _expensesCRepo = expensesCRepo;
    }

    
    // GET
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var vm = new ExpensesCVm();
        vm.Categories = await _expensesCRepo.GetAllAsync();
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ExpensesCVm vm)
    {
        try
        {
            var dto = new ExpensesCDto()
            {
                Name = vm.Name,
                Description = vm.Description
            };
            await _expensesCService.CreateExpenses(dto);
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
           await _expensesCService.Delete(id);
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