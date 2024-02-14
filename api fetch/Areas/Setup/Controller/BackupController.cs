using System.Diagnostics;
using api_fetch.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Setup.Controller;

[Area("setup")]
public class BackupController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IConfiguration _configuration;

    public BackupController(IWebHostEnvironment hostEnvironment,
        IConfiguration configuration)
    {
        _hostEnvironment = hostEnvironment;
        _configuration = configuration;
    }

    // GET
    public IActionResult Index()
    {
        var info = new DirectoryInfo(GetBackupPath());
        var backups = info.GetFiles().OrderByDescending(x => x.LastWriteTimeUtc)
            .Select(x => x.Name).ToArray();
        return View(backups);
    }

    [HttpPost]
    public async Task<IActionResult> New(string remarks)
    {
        var data = DatabaseInfoExtensions.GetDbInfo(_configuration.GetConnectionString("DefaultConnection")!);
        var backupDir = GetBackupPath();
        await BackupDatabase(
            data.Server,
            data.Port,
            data.UserName,
            data.Password,
            data.DatabaseName,
            backupDir,
            "Backup_" + remarks.Trim().Replace(" ", "_") + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".bak",
            backupCommandDir: _configuration["backup_dir"] ?? ""
        );
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Restore(string backupFile)
    {
        var data = DatabaseInfoExtensions.GetDbInfo(_configuration.GetConnectionString("Default")!);
        var backupDir = GetBackupPath();
        await RestoreDatabase(
            data.Server,
            data.Port,
            data.UserName,
            data.Password,
            data.DatabaseName,
            backupDir,
            backupFile,
            backupCommandDir: _configuration["backup_dir"] ?? ""
        );
        return RedirectToAction("Index");
    }

    public IActionResult Download(string fileName)
    {
        var backupDir = GetBackupPath();
        var filePath = Path.Combine(backupDir, fileName);
        if (System.IO.File.Exists(filePath))
        {
            return PhysicalFile(filePath, "application/octet-stream", fileName);
        }
        else
        {
            return NotFound();
        }
    }
    private async Task BackupDatabase(
        string server,
        string port,
        string user,
        string password,
        string dbname,
        string backupDir,
        string backupFileName,
        string backupCommandDir)
    {
        const string pwdKey = "PGPASSWORD";
        try
        {
            Environment.SetEnvironmentVariable(pwdKey, password);
            var dateTime = DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss");

            Directory.CreateDirectory(backupDir);

            string backupFile = Path.Combine(backupDir, backupFileName);

            string backupString = "-F t -f \"" + backupFile + "\" " +
                                  " -h " + server + " -U " + user + " -p " + port + " -d " + dbname;

            Process proc = new Process();
            proc.StartInfo.FileName = Path.Combine(backupCommandDir, "pg_dump");

            proc.StartInfo.Arguments = backupString;

            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;


            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            proc.Start();
            var error = await proc.StandardError.ReadToEndAsync();
            await proc.WaitForExitAsync();
            if (proc.ExitCode != 0)
            {
                proc.Close();
                throw new Exception("Error backing up database. " +
                                    error);
            }

            proc.Close();
        }
        
        finally
        {
            Environment.SetEnvironmentVariable(pwdKey, "");
        }
    }
    
    private async Task RestoreDatabase(
        string server,
        string port,
        string user,
        string password,
        string dbname,
        string backupDir,
        string backupFile,
        string backupCommandDir)
    {
        const string pwdKey = "PGPASSWORD";
        try
        {
            Environment.SetEnvironmentVariable(pwdKey, password);

            backupFile = Path.Combine(backupDir, backupFile);

            string restoreString =
                $"-c --single-transaction -h \"{server}\" -U \"{user}\" -p {port} -d \"{dbname}\" \"{backupFile}\"";

            Process proc = new Process();
            proc.StartInfo.FileName = Path.Combine(backupCommandDir, "pg_restore");

            proc.StartInfo.Arguments = restoreString;

            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;

            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            proc.Start();
            string output = proc.StandardOutput.ReadToEnd();
            var error = proc.StandardError.ReadToEnd();
            proc.WaitForExit();
            if (proc.ExitCode != 0)
            {
                proc.Close();
                throw new Exception("Error restoring database. " +
                                    error);
            }

            proc.Close();
        }
        finally
        {
            Environment.SetEnvironmentVariable(pwdKey, "");
        }
    }
    
    private string GetBackupPath()
    {
        var path = Path.Combine(_hostEnvironment.WebRootPath, "backups");
        Directory.CreateDirectory(path);
        return path;    
    }
}