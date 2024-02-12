using App.Base.DataContext;
using App.Base.DataContext.Interface;
using App.Base.Providers;
using App.Base.Providers.Interface;
using App.Base.Services;
using App.Base.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace App.Base;

public static class DiConfig
{
    public static IServiceCollection BaseConfig(this IServiceCollection services)
    {
        services.AddScoped<IUow,Uow>();
        services.AddScoped<IConnectionProvider,ConnectionProvider>();
        services.AddScoped<IBackupService,BackupService>();
        return services;
    }
}