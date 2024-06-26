using App.Expenses.Providers;
using App.Expenses.Providers.Interface;
using App.Expenses.Repository;
using App.Expenses.Repository.Interface;
using App.Expenses.Service;
using App.Expenses.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace App.Expenses;

public static class DiConfig
{
    public static IServiceCollection UseRootConfig(this IServiceCollection service)
    {
        service.AddScoped<IExpensesRecordRepository, ExpensesRecordRepository>();
        service.AddScoped<IIncomeRecordRepository, IncomeRecordRepository>();

        service.AddScoped<IExpensesRecordService, ExpensesRecordService>();
        service.AddScoped<IIncomeService, IncomeService>();

        service.AddScoped<IExpensesProvider, ExpensesProvider>();
        service.AddScoped<IIncomeProvider, IncomeProvider>();
        return service;
    }
}