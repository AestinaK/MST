using api_fetch.Areas.Root.ViewModel.Expenses;
using api_fetch.Provider.Interface;
using App.Expenses.Dto;
using App.Expenses.Service.Interface;
using App.Setup.Repository.Interface;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Root.Controller;

[Area("root")]
public class ExpensesController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IExpensesCRepository _expensesCRepo;
    private readonly IUserProvider _userPro;
    private readonly IExpensesRecordService _expensesRecordService;
    private readonly INotyfService _notyfService;

    public ExpensesController(IExpensesCRepository expensesCRepo,
        IUserProvider userPro,
        IExpensesRecordService expensesRecordService,
        INotyfService notyfService)
    {
        _expensesCRepo = expensesCRepo;
        _userPro = userPro;
        _expensesRecordService = expensesRecordService;
        _notyfService = notyfService;
    }

    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var vm = new ExpensesVm();
        vm.Categories = await _expensesCRepo.GetAllAsync();
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ExpensesVm vm)
    {
        var user = _userPro.GetCurrentUser();
            var dto = new CreateExpensesDto()
            {
                UserId = user.Id,
                Amount = vm.Amount,
                ExpensesId = vm.Expenses,
                Status = vm.Status,
                TxnDate = vm.Date,
                Descrption = vm.Description
            };
            await _expensesRecordService.CreateExpensesRecord(dto);
            _notyfService.Success("Added!");

            return RedirectToAction(nameof(Add));
    }
}