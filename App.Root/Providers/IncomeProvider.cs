using App.Base.Providers.Interface;
using App.Expenses.Dto;
using App.Expenses.Providers.Interface;
using Dapper;

namespace App.Expenses.Providers;

public class IncomeProvider : IIncomeProvider
{
    private readonly IConnectionProvider _connectionProvider;

    public IncomeProvider(IConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<List<SearchIncomeDto>> GetIncomeList(DateTime date)
    {
        await using var conn = _connectionProvider.GetConnection();
        return (await conn.QueryAsync<SearchIncomeDto>(query, new
        {
            date = date
        })).ToList();
    }
    
    
    private const string query = @"select i.""Id"", i.""Amount"", i.""Date"", ic.""Name""
    from root.income_record i
    join setup.income_category ic on i.""CategoryId"" = ic.""Id""
    where i.""Date""::date <= @date::date;";
}