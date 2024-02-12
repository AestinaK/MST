using Microsoft.EntityFrameworkCore;

namespace App.User;

public static class EntityRegistrar
{
     public static ModelBuilder AddUser(this ModelBuilder builder)
     {
        builder.Entity<Model.User>();
         return builder;
     }
}