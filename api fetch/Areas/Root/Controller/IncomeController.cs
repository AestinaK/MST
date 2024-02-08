using api_fetch.Areas.Root.ViewModel.Income;
using api_fetch.Provider.Interface;
using App.Base.Extensions;
using App.Base.ValueObject;
using App.Expenses.Dto;
using App.Expenses.Repository;
using App.Expenses.Repository.Interface;
using App.Expenses.Service.Interface;
using App.Setup.Repository.Interface;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_fetch.Areas.Root.Controller;

[Area("root")]
public class IncomeController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IIncomeCRepository _incomeCRepo;
    private readonly IUserProvider _userProvider;
    private readonly IIncomeService _incomeService;
    private readonly INotyfService _notyfService;
    private readonly IIncomeRecordRepository _incomeRecordRepo;

    public IncomeController(IIncomeCRepository incomeCRepo,
        IUserProvider userProvider,
        IIncomeService incomeService,
        INotyfService notyfService,
        IIncomeRecordRepository incomeRecordRepo)
    {
        _incomeCRepo = incomeCRepo;
        _userProvider = userProvider;
        _incomeService = incomeService;
        _notyfService = notyfService;
        _incomeRecordRepo = incomeRecordRepo;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var vm = new IncomeSearchVm();
        vm.Date = DateTime.Today;
        vm.Incomes = await FilterIncome(vm);
        return View(vm);
    }

    public async Task<PagedResult<IncomeInfo>> FilterIncome(IncomeSearchVm vm)
    {
        var income = _incomeCRepo.GetQueryable();
        var incomeRecord = _incomeRecordRepo.GetQueryable()
            .Where(x => x.Date <= vm.Date);
        var result = await (from i in incomeRecord
            join r in income on i.CategoryId equals r.Id
            select new IncomeInfo()
            {
                Id = i.Id,
                Source = r.Name,
                Amount = i.Amount,
                Date = i.Date
            }).PaginateAsync(vm.Page, vm.Limit);
        return result;
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