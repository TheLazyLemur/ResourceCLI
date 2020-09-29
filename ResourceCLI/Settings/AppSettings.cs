namespace ResourceCLI.Settings
{
    public class AppSettings
    {
        public static string ConnectionString = $"/{System.Environment.GetEnvironmentVariable("HOME")}/.config/ResourceCli/Items.Db";
    }
}