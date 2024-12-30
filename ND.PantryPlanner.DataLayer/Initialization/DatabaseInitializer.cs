using Microsoft.Data.Sqlite;

using ND.PantryPlanner.Common.App;

namespace ND.PantryPlanner.DataLayer.Initialization
{

  public class DatabaseInitializer
  {
    private readonly string _databasePath;

    public DatabaseInitializer()
    {
      var baseDirectory = AppContext.BaseDirectory;
      var subFolder = Path.Combine(baseDirectory, ".local", "share");
      _databasePath = Path.Combine(subFolder, Settings.DatabaseFileName);
    }

    public void Initialize()
    {
      var directory = Path.GetDirectoryName(_databasePath);

      if (!Directory.Exists(directory))
      {
        Directory.CreateDirectory(path: directory);
      }

      if (!File.Exists(_databasePath))
      {
        File.Create(_databasePath).Close();
      }

      using (var connection = new SqliteConnection($"Data Source={_databasePath}"))
      {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @$"
          CREATE TABLE IF NOT EXISTS Item (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Quantity INTEGER NOT NULL
          );";

        command.ExecuteNonQuery();
      }
    }
  }
}
