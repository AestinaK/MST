using App.Base.Providers.Interface;
using App.Base.Services.Interface;
using Dapper;

namespace App.Base.Services;

public class BackupService : IBackupService
{
    private readonly IConnectionProvider _connectionProvider;

    public BackupService(IConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task CreateBackup(string filepath)
    {
        await using var conn = _connectionProvider.GetConnection();
        var query = @"BACKUP DATABASE [{conn.Database}] TO DISK = @FilePath";
        await conn.ExecuteAsync(query, new { FilePath = filepath });
    }
}