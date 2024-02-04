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

        service.AddScoped<IExpensesRecordService, ExpensesRecordService>();
        return service;
    }
}