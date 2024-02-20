using App.Setup.Repository;
using App.Setup.Repository.Interface;
using App.Setup.Service;
using App.Setup.Service.Interface;
using App.Setup.Validators;
using App.Setup.Validators.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace App.Setup;

public static class DiConfig
{
    public static IServiceCollection SetupConfig(this IServiceCollection services)
    {
        //Repositories
        services.AddScoped<IExpensesCRepository, ExpensesCRepository>();
        services.AddScoped<IIncomeCRepository,IncomeCRepository>();
        services.AddScoped<IReminderRepository, ReminderRepository>();

        //Services
        services.AddScoped<IExpensesCService, ExpensesCService>();
        services.AddScoped<IIncomeCService, IncomeCService>();
        services.AddScoped<IReminderService, ReminderService>();

        //validators
        services.AddScoped<ICategoryValidator,CategoryValidator>();
        return services;
    }
}