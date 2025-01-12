using Microsoft.Data.Sqlite;

using ND.PantryPlanner.Common.App;
using ND.PantryPlanner.ModelLayer.DatabaseStructures.Schemas;

namespace ND.PantryPlanner.DataLayer.Initialization
{

  public class DatabaseInitializer
  {
    private readonly string _databasePath;

    public DatabaseInitializer()
    {
      var baseDirectory = AppContext.BaseDirectory;
      var subFolder = Path.Combine(baseDirectory, ".local", "data");
      _databasePath = Path.Combine(subFolder, Settings.DatabaseFileName);
    }

    public void Initialize()
    {
      var directory = Path.GetDirectoryName(Settings.DatabasePath);// _databasePath);

      if (!Directory.Exists(directory))
      {
        Directory.CreateDirectory(path: directory!);
      }

      if (!File.Exists(_databasePath))
      {
        File.Create(_databasePath).Close();
      }

      using (var connection = new SqliteConnection($"Data Source={_databasePath}"))
      {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = Schemas.DatabaseSchema;

        command.ExecuteNonQuery();
      }
    }
  }
}
