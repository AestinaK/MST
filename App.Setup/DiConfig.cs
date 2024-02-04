using App.Setup.Repository;
using App.Setup.Repository.Interface;
using App.Setup.Service;
using App.Setup.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace App.Setup;

public static class DiConfig
{
    public static IServiceCollection SetupConfig(this IServiceCollection services)
    {
        services.AddScoped<IExpensesCRepository, ExpensesCRepository>();
        services.AddScoped<IncomeCRepository, IncomeCRepository>();

        services.AddScoped<IExpensesCService, ExpensesCService>();
        return services;
    }
}