using App.Setup.Model;
using Microsoft.EntityFrameworkCore;

namespace App.Setup;

public static class EntityRegistrar
{
    public static ModelBuilder AddSetup(this ModelBuilder builder)
    {
        builder.Entity<ExpensesCategory>();
        builder.Entity<IncomeCategory>();
        return builder;
    } 
}