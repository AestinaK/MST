using App.Expenses.Repository.Interface;
using App.Setup.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Api.Controller;

[ApiController]
public class IncomeExpensesController : ControllerBase
{
    private readonly IIncomeCRepository _incomeCRepo;
    private readonly IExpensesCRepository _expensesCRepo;
    private readonly IIncomeRecordRepository _incomeRecordRepo;
    private readonly IExpensesRecordRepository _expensesRecordRepo;

    public IncomeExpensesController(IIncomeCRepository incomeCRepo,
        IExpensesCRepository expensesCRepo,
        IIncomeRecordRepository incomeRecordRepo,
        IExpensesRecordRepository expensesRecordRepo)
    {
        _incomeCRepo = incomeCRepo;
        _expensesCRepo = expensesCRepo;
        _incomeRecordRepo = incomeRecordRepo;
        _expensesRecordRepo = expensesRecordRepo;
    }

    [HttpGet("/Api/IncomeExpenses/GetIncomeByCategory")]
    public IActionResult GetIncomeByCategory()
    {
        var category = _incomeCRepo.GetQueryable();
        var income = _incomeRecordRepo.GetQueryable();
        var data = (from i in income
            join c in category on i.CategoryId equals c.Id
            select new
            {
                name = c.Name,
                amount = i.Amount
            }).ToList();
        return Ok(data);
    }


    [HttpGet("/Api/IncomeExpenses/GetExpensesByCategory")]
    public IActionResult GetExpensesByCategory()
    {
        var category = _expensesCRepo.GetQueryable();
        var expenses = _expensesRecordRepo.GetQueryable();
        var data = (from i in expenses
            join c in category on i.ExpensesId equals c.Id
            select new
            {
                name = c.Name,
                amount = i.Amount
            }).ToList();
        return Ok(data);
    }
}