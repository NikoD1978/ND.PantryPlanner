namespace ND.PantryPlanner.Common.App
{
  public static class Settings
  {
    // "Data Source=hello.db"
    public const string DatabaseFileName = "app.db";
    public const string DatabaseName = "ND.PantryPlanner";

    public static string DatabasePath = Path.Combine(AppContext.BaseDirectory, ".local", "data", DatabaseFileName);
    public static string ConnectionString = @$"Data Source={DatabasePath}";
  }
}
