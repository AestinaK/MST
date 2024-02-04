using App.Expenses.Model;
using Microsoft.EntityFrameworkCore;

namespace App.Expenses;

public static class EntityRegistrar
{
    public static ModelBuilder AddRoot(this ModelBuilder builder)
    {
        builder.Entity<ExpensesRecord>().Property(x => x.Status).HasConversion<String>();
        return builder;
    }
}