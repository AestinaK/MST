using App.Expenses.Repository;
using App.Expenses.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace App.Expenses;

public static class DiConfig
{
    public static IServiceCollection UseRoot(this IServiceCollection service)
    {
        service.AddScoped<IExpensesRecordRepository, ExpensesRecordRepository>();
        return service;
    }
}