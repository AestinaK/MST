namespace App.Base.Services.Interface;

public interface IBackupService
{
    Task CreateBackup(string filepath);
}