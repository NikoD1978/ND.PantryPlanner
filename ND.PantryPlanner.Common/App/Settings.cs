namespace ND.PantryPlanner.Common.App
{
  public static class Settings
  {
    // "Data Source=hello.db"
    public const string DatabaseFileName = "app.db";
    public const string DatabaseName = "ND.PantryPlanner";
    public const string ConnectionString = @$"
      Data Source={DatabaseFileName};
      Initial Catalog={DatabaseName};
      Integrated Security=True";
  }
}
