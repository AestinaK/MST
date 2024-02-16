using api_fetch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using api_fetch.ViewModel;
using App.Base.Constants;
using App.Expenses.Repository.Interface;

namespace api_fetch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIncomeRecordRepository _incomeRecordRepo;
        private readonly IExpensesRecordRepository _expensesRecordRepo;

        public HomeController(ILogger<HomeController> logger,
            IIncomeRecordRepository incomeRecordRepo,
            IExpensesRecordRepository expensesRecordRepo)
        {
            _logger = logger;
            _incomeRecordRepo = incomeRecordRepo;
            _expensesRecordRepo = expensesRecordRepo;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new IndexDataVm();
            vm.TotalExpenses = _expensesRecordRepo.GetQueryable()
                .Where(x => x.RecStatus == Status.Active).Sum(x => x.Amount);

            vm.TotalIncome = _incomeRecordRepo.GetQueryable().Where(x => x.RecStatus == Status.Active)
                .Sum(x => x.Amount);
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}