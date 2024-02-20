using api_fetch.Areas.Setup.ViewModel.Reminder;
using App.Setup.Provider.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Setup.Controller;

[Area("setup")]
public class ReminderController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IExpensesCategoryProvider _expensesCategoryProvider;

    public ReminderController(IExpensesCategoryProvider expensesCategoryProvider)
    {
        _expensesCategoryProvider = expensesCategoryProvider;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var vm = new ReminderVm();
        vm.DueDate = DateTime.Today;
        vm.Categories =await _expensesCategoryProvider.GetCategoryAsync();
        return View(vm);
    }
}