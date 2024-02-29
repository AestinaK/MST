using api_fetch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using api_fetch.ViewModel;
using App.Base.Constants;
using App.Expenses.Repository.Interface;
using App.Setup.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace api_fetch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIncomeRecordRepository _incomeRecordRepo;
        private readonly IExpensesRecordRepository _expensesRecordRepo;
        private readonly IReminderRepository _reminderRepo;
        private readonly IExpensesCRepository _expensesCRepo;

        public HomeController(ILogger<HomeController> logger,
            IIncomeRecordRepository incomeRecordRepo,
            IExpensesRecordRepository expensesRecordRepo,
            IReminderRepository reminderRepo,
            IExpensesCRepository expensesCRepo)
        {
            _logger = logger;
            _incomeRecordRepo = incomeRecordRepo;
            _expensesRecordRepo = expensesRecordRepo;
            _reminderRepo = reminderRepo;
            _expensesCRepo = expensesCRepo;
        }

        public async Task<IActionResult> Index()
        {
            DateTime today = DateTime.Today;
            DateTime nextMonth = today.AddMonths(1).AddDays(1 - today.Day);
            DateTime lastDate = nextMonth.AddDays(-7);
            var vm = new IndexDataVm();
            vm.TotalExpenses = _expensesRecordRepo.GetQueryable()
                .Where(x => x.RecStatus == Status.Active).Sum(x => x.Amount);

            vm.TotalIncome = _incomeRecordRepo.GetQueryable().Where(x => x.RecStatus == Status.Active)
                .Sum(x => x.Amount);

            // var category = _expensesCRepo.GetQueryable();
            // var reminders = _reminderRepo.GetQueryable().Where(x => x.DueDate >= today && x.DueDate< nextMonth);
            //
            // vm.Reminders = await (from r in reminders
            //     join c in category on r.CategoryId equals c.Id
            //     select new ReminderVm()
            //     {
            //         Id = r.Id,
            //         Name = c.Name,
            //         Date = r.DueDate,
            //         DueDays = (nextMonth - r.DueDate).Days
            //     }).ToListAsync();
            var categories = await _expensesCRepo.GetQueryable().ToListAsync();
            var reminders = await _reminderRepo.GetQueryable().ToListAsync();

            vm.Reminders = new List<ReminderVm>();

            foreach (var category in categories)
            {
                var categoryReminders = from r in reminders
                    where r.CategoryId == category.Id &&
                          r.DueDate >= today &&
                          r.DueDate < nextMonth &&
                          r.RecStatus == Status.Active
                    select new ReminderVm
                    {
                        Id = r.Id,
                        Name = category.Name,
                        Date = r.DueDate,
                        DueDays = (r.DueDate - today).Days
                    };

                vm.Reminders.AddRange(categoryReminders);
            }
            
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