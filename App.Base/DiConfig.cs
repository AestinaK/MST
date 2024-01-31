using App.Base.DataContext;
using App.Base.DataContext.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace App.Base;

public static class DiConfig
{
    public static IServiceCollection BaseConfig(this IServiceCollection services)
    {
        services.AddScoped<IUow,Uow>();
        return services;
    }
}