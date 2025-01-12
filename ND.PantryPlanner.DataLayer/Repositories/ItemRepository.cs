using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Data.Sqlite;

using ND.PantryPlanner.Common.App;
using ND.PantryPlanner.Common.Interfaces;
using ND.PantryPlanner.ModelLayer.Enums;
using ND.PantryPlanner.ModelLayer.Models;

namespace ND.PantryPlanner.DataLayer.Repositories
{
  /// <summary>
  /// Repository for getting stored items and their information as well as adding new items
  /// </summary>
  public class ItemRepository : IRepository<Item>
  {
    /// <summary>
    /// Gets all items from the database
    /// </summary>
    public ObservableCollection<Item> Get()
    {
      var result = new ObservableCollection<Item>();

      using (var connection = new SqliteConnection(Settings.ConnectionString))
      {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @$"
            SELECT  ITEM_ID,
                    ITEM_NAME,
                    ITEM_DESCRIPTION,
                    ITEM_ITEM_TYPE,
                    ITEM_LOCATION_TYPE,
                    ITEM_QUANTITY,
                    ITEM_EXPIRATION_DATE,
                    ITEM_HAS_TO_BE_REFRIGERATED,
                    ITEM_IMAGE_PATH
            FROM ND_ITEMS;
          ";
        //command.Parameters.AddWithValue("$id", id);

        try
        {
          using (var reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              //var name = reader.GetString(0);

              result.Add(new Item
              {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                ItemType = (ItemType)reader.GetInt32(3),
                LocationType = (LocationType)reader.GetInt32(4),
                Quantity = reader.GetInt32(5),
                ExpirationDate = Convert.ToDateTime(reader.GetString(6)),
                HasToBeRefrigerated = reader.GetBoolean(7),
                ImagePath = reader.GetString(8)
              });

              //Debug.WriteLine($"Hello, {name}!");
            }
          }
        }
        catch (SqliteException e)
        {
          // TODO: Make up my mind about how I want to handle and document exceptions
          Debug.WriteLine($"An error occurred: {e.Message}");
          throw;
        }
        finally
        {
          connection.Close();
        }

        return result;
      }
    }

    /// <summary>
    /// Gets a single item by its ID
    /// </summary>
    public Item? Get(int id)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a new item to the database
    /// </summary>
    public void Add(Item item)
    {
      throw new NotImplementedException();
    }
  }
}
