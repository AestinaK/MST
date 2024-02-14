using api_fetch.Areas.Root.ViewModel.Expenses;
using api_fetch.Provider.Interface;
using App.Base.Extensions;
using App.Base.ValueObject;
using App.Expenses.Dto;
using App.Expenses.Providers.Interface;
using App.Expenses.Repository.Interface;
using App.Expenses.Service.Interface;
using App.Setup.Repository.Interface;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pioneer.Pagination;

namespace api_fetch.Areas.Root.Controller;

[Area("root")]
public class ExpensesController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IExpensesCRepository _expensesCRepo;
    private readonly IUserProvider _userPro;
    private readonly IExpensesRecordService _expensesRecordService;
    private readonly INotyfService _notyfService;
    private readonly IExpensesRecordRepository _expensesRecordRepo;
    private readonly IExpensesProvider _expensesProvider;

    public ExpensesController(IExpensesCRepository expensesCRepo,
        IUserProvider userPro,
        IExpensesRecordService expensesRecordService,
        INotyfService notyfService,
        IExpensesRecordRepository expensesRecordRepo,
        IExpensesProvider expensesProvider)
    {
        _expensesCRepo = expensesCRepo;
        _userPro = userPro;
        _expensesRecordService = expensesRecordService;
        _notyfService = notyfService;
        _expensesRecordRepo = expensesRecordRepo;
        _expensesProvider = expensesProvider;
    }
    
    public async Task<IActionResult> Index(ExpensesSearchVm vm)
    {
        vm.Categories = await _expensesProvider.GetExpensesList(vm.Date);
        return View(vm);
    }
    
    [HttpGet]
    public async Task<IActionResult> Add()
    {
         var vm = new ExpensesVm();
         vm.Date = DateTime.Today;
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
    
    [HttpGet]
    public async Task<IActionResult> Update(long id)
    {
        var data = await _expensesRecordRepo.FindAsync(id);
        var vm = new UpdateExpVm();
        vm.Categories = await _expensesCRepo.GetAllAsync();
        vm.Amount = data.Amount;
        vm.Description = data.Description;
        vm.Date = data.TxnDate;
        vm.ExpensesId = data.ExpensesId;
        vm.Status = data.Status;
        return View(vm);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(UpdateExpVm vm)
    {
        try
        {
            var dto = new ExpUpdateDto()
            {
                Id = vm.Id,
                Amount = vm.Amount,
                ExpensesId = vm.ExpensesId,
                TxnDate = vm.Date,
                Descrption = vm.Description,
                Status = vm.Status
            };
            await _expensesRecordService.Update(dto);
            _notyfService.Success("Updated!");
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
            await _expensesRecordService.Delete(id);
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