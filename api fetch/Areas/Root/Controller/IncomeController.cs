using api_fetch.Areas.Root.ViewModel.Income;
using api_fetch.Provider.Interface;
using App.Expenses.Dto;
using App.Expenses.Service.Interface;
using App.Setup.Repository.Interface;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Root.Controller;

[Area("root")]
public class IncomeController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IIncomeCRepository _incomeCRepo;
    private readonly IUserProvider _userProvider;
    private readonly IIncomeService _incomeService;
    private readonly INotyfService _notyfService;

    public IncomeController(IIncomeCRepository incomeCRepo,
        IUserProvider userProvider,
        IIncomeService incomeService,
        INotyfService notyfService)
    {
        _incomeCRepo = incomeCRepo;
        _userProvider = userProvider;
        _incomeService = incomeService;
        _notyfService = notyfService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View();
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var vm = new IncomeVm();
        vm.Date = DateTime.Today;
        vm.IncomeCategories = await _incomeCRepo.GetAllAsync();
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Add(IncomeVm vm)
    {
            var user = _userProvider.GetCurrentUser();
            var dto = new IncomeDto()
            {
                UserId = user.Id,
                Amount = vm.Amount,
                CategoryId = vm.CategoryId,
                Date = vm.Date,
                Description = vm.Description
            };
            await _incomeService.Create(dto);
            _notyfService.Success("Added!");
        return RedirectToAction(nameof(Add));
    }
}