using api_fetch.Areas.Root.ViewModel.Income;
using api_fetch.Provider.Interface;
using App.Expenses.Dto;
using App.Expenses.Providers.Interface;
using App.Expenses.Repository.Interface;
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
    private readonly IIncomeRecordRepository _incomeRecordRepo;
    private readonly IIncomeProvider _incomeProvider;

    public IncomeController(IIncomeCRepository incomeCRepo,
        IUserProvider userProvider,
        IIncomeService incomeService,
        INotyfService notyfService,
        IIncomeRecordRepository incomeRecordRepo,
        IIncomeProvider incomeProvider )
    {
        _incomeCRepo = incomeCRepo;
        _userProvider = userProvider;
        _incomeService = incomeService;
        _notyfService = notyfService;
        _incomeRecordRepo = incomeRecordRepo;
        _incomeProvider = incomeProvider;
    }

    [HttpGet]
    public async Task<IActionResult> Index(IncomeSearchVm vm)
    {
       vm.Incomes = await _incomeProvider.GetIncomeList(vm.Date);
        return View(vm);
    }

    // public async Task<PagedResult<IncomeInfo>> FilterIncome(IncomeSearchVm vm)
    // {
    //     var income = _incomeCRepo.GetQueryable();
    //     var incomeRecord = _incomeRecordRepo.GetQueryable()
    //         .Where(x => x.Date <= vm.Date);
    //     var result = await (from i in incomeRecord
    //         join r in income on i.CategoryId equals r.Id
    //         select new IncomeInfo()
    //         {
    //             Id = i.Id,
    //             Source = r.Name,
    //             Amount = i.Amount,
    //             Date = i.Date
    //         }).PaginateAsync(vm.Page, vm.Limit);
    //     return result;
    // }

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

    [HttpGet]
    public async Task<IActionResult> Update(long id)
    {
        var vm = new UpdateIncomeVm();
        var data = await _incomeRecordRepo.FindAsync(id);
        vm.Date = data.Date;
        vm.CategoryId = data.CategoryId;
        vm.Amount = data.Amount;
        vm.IncomeCategories = await _incomeCRepo.GetAllAsync();
        vm.Description = data.Description;
        return View(vm);
    }

    public async Task<IActionResult> Update(UpdateIncomeVm vm)
    {
        try
        {
            var dto = new IncomeUpdateDto()
            {
                Id = vm.Id,
                Amount = vm.Amount,
                CategoryId = vm.CategoryId,
                Description = vm.Description,
                Date = vm.Date
            };
            await _incomeService.Update(dto);
            _notyfService.Success("Updated");
        }
        catch (Exception e)
        {
          _notyfService.Error(e.Message);
          return Redirect("/");
        }
        return RedirectToAction(nameof(Update));
    }
    
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _incomeService.Delete(id);
            _notyfService.Success("Deleted!");
        }
        catch (Exception e)
        {
           _notyfService.Error(e.Message);
           return Redirect("/");
        }
    
        return RedirectToAction(nameof(Index));
    }
}