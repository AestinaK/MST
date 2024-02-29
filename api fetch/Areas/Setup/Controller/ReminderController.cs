using api_fetch.Areas.Setup.ViewModel.Reminder;
using App.Setup.Dto;
using App.Setup.Provider.Interface;
using App.Setup.Repository.Interface;
using App.Setup.Service.Interface;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_fetch.Areas.Setup.Controller;

[Area("setup")]
public class ReminderController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IExpensesCategoryProvider _expensesCategoryProvider;
    private readonly IReminderService _reminderService;
    private readonly INotyfService _notyfService;
    private readonly IExpensesCRepository _expensesCRepo;
    private readonly IReminderRepository _reminderRepo;

    public ReminderController(IExpensesCategoryProvider expensesCategoryProvider,
        IReminderService reminderService,
        INotyfService notyfService,
        IExpensesCRepository expensesCRepo,
        IReminderRepository reminderRepo)
    {
        _expensesCategoryProvider = expensesCategoryProvider;
        _reminderService = reminderService;
        _notyfService = notyfService;
        _expensesCRepo = expensesCRepo;
        _reminderRepo = reminderRepo;
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
        vm.Categories = await _expensesCategoryProvider.GetCategoryAsync();
        var categories = _expensesCRepo.GetQueryable();
        var reminders = _reminderRepo.GetQueryable();
        vm.Reminders = await (from r in reminders
            join c in categories on r.CategoryId equals c.Id
            select new ReminderInfoVm()
            {
                Id = r.Id,
                Name = c.Name,
                Date = r.DueDate
            }).ToListAsync();
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ReminderVm vm)
    {
        try
        {
            var dto = new ReminderDto()
            {
                CategoryId = vm.CategoryId,
                DueDate = vm.DueDate,
                Description = vm.Description
            };
            await _reminderService.Create(dto);
            _notyfService.Success("Reminder added!");
        }
        catch (Exception e)
        {
            _notyfService.Error(e.Message);
            return Redirect("/");
        }

        return RedirectToAction(nameof(Add));
    }
}