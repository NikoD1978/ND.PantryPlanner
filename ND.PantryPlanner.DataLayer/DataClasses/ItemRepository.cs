using System.Collections.ObjectModel;

using Microsoft.Data.Sqlite;

using ND.PantryPlanner.Common.App;
using ND.PantryPlanner.Common.Interfaces;
using ND.PantryPlanner.EntityLayer.EntityClasses;

namespace ND.PantryPlanner.DataLayer.DataClasses
{
  public class ItemRepository : IRepository<Item>
  {
    public ObservableCollection<Item> Get()
    {
      var result = new ObservableCollection<Item>();

      using (var connection = new SqliteConnection(Settings.ConnectionString))
      {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @$"
          SELECT name
          FROM user
          WHERE id = $id
        ";
        //command.Parameters.AddWithValue("$id", id);

        try
        {
          using (var reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              var name = reader.GetString(0);

              Console.WriteLine($"Hello, {name}!");
            }
          }
        }
        catch (SqliteException e)
        {
          // TODO: Make up my mind about how I want to handle and document exceptions
          //Console.WriteLine($"An error occurred: {e.Message}");
        }
        finally
        {
          connection.Close();
        }

        return result;
      }
    }

    public Item? Get(int id)
    {
      throw new NotImplementedException();
    }

    public void Add(Item entity)
    {
      throw new NotImplementedException();
    }
  }
}
