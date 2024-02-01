using App.User.Repository;
using App.User.Repository.Interface;
using App.User.Service;
using App.User.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace App.User;

public static class DiConfig
{
     public static IServiceCollection UserConfiguration(this IServiceCollection services)
     {
          services.AddScoped<IUserService,UserService>();
          services.AddScoped<IUserRepository,UserRepository>();
          return services;
     }
        

}