using api_fetch.Areas.Setup.ViewModel.ExpensesC;
using App.Setup.Dto;
using App.Setup.Service.Interface;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Setup.Controller;

[Area("setup")]
public class ExpensesCController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IExpensesCService _expensesCService;
    private readonly INotyfService _notyfService;

    public ExpensesCController(IExpensesCService expensesCService,
        INotyfService notyfService)
    {
        _expensesCService = expensesCService;
        _notyfService = notyfService;
    }

    // GET
    [HttpGet]
    public IActionResult Add()
    {
        var vm = new ExpensesCVm();
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
}