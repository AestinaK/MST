using App.Base.Providers.Interface;
using App.Expenses.Dto;
using App.Expenses.Providers.Interface;
using Dapper;

namespace App.Expenses.Providers;

public class ExpensesProvider : IExpensesProvider
{
    private readonly IConnectionProvider _connectionProvider;

    public ExpensesProvider(IConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<List<SearchExpensesDto>> GetExpensesList(DateTime date)
    {
        await using var conn = _connectionProvider.GetConnection();
        return (await conn.QueryAsync<SearchExpensesDto>(query, new
        {
            date = date
        })).ToList();
    }
    
    private const string query = @"select i.""Id"", i.""Amount"",i.""TxnDate"" ,ic.""Name"", i.""Status""
    from root.""expenses_Record"" i
        join setup.income_category ic on i.""ExpensesId"" = ic.""Id""
    where i.""TxnDate""::date <= @date::date
        ;";



}