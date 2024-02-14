namespace api_fetch.Extensions;

public static class DatabaseInfoExtensions
{
    public static DbInfo GetDbInfo(string connectionString)
    {
        string server = "", port = "", username = "", database = "", password = "";
        var parts = connectionString.Trim(';').Split(';');
        foreach (var part in parts)
        {
            var keyValue = part.Split('=');
            var key = keyValue[0]?.Trim()?.ToLower();
            var value = keyValue[1]?.Trim();
            switch (key)
            {
                case "server":
                    server = value;
                    break;
                case "port":
                    port = value;
                    break;
                case "username":
                    username = value;
                    break;
                case "database":
                    database = value;
                    break;
                case "password":
                    password = value;
                    break;
            }
        }

        return new DbInfo
            { Server = server, Port = port, DatabaseName = database, UserName = username, Password = password };
    }
}

public class DbInfo
{
    public string Server { get; set; }
    public string Port { get; set; }
    public string DatabaseName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

}