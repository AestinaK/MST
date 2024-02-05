using DateConverter.Converters;
using DateConverter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DateConverter;

public static class DiConfig
{
    public static IServiceCollection UseNepaliDateConfig(this IServiceCollection service)
    {
        service.AddSingleton<INepaliDateConverter, NepaliDateConverter>();
        return service;
    }
}