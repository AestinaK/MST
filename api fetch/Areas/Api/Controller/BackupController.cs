using App.Base.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Api.Controller;

[ApiController]
[Route("[controller]")]
public class BackupController : ControllerBase
{
    private readonly IBackupService _backupService;

    public BackupController(IBackupService backupService)
    {
        _backupService = backupService;
    }

   [HttpPost("/Api/Backup/Backup")]
    public async Task<IActionResult> Backup()
    {
        try
        {
            var file = "D:\\temp_dbs\\backup.bak";
            await _backupService.CreateBackup(file);
            return Ok("Backup Completed!");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}