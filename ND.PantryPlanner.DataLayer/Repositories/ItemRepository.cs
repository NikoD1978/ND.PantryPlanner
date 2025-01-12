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
  public partial class ItemRepository : IRepository<Item>
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
              result.Add(new Item
              {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                ItemType = (ItemType)reader.GetInt32(3),
                LocationType = (LocationType)reader.GetInt32(4),
                Quantity = reader.GetInt32(5),
                ExpirationDate = reader.IsDBNull(6) ? (DateTime?)null : Convert.ToDateTime(reader.GetString(6)),
                HasToBeRefrigerated = reader.GetBoolean(7),
                ImagePath = reader.IsDBNull(8) ? null : reader.GetString(8),
              });
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
    public bool Add(Item item)
    {
      using (var connection = new SqliteConnection(Settings.ConnectionString))
      {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @$"
          INSERT INTO ND_ITEMS (
            ITEM_NAME,
            ITEM_DESCRIPTION,
            ITEM_ITEM_TYPE,
            ITEM_LOCATION_TYPE,
            ITEM_QUANTITY,
            ITEM_EXPIRATION_DATE,
            ITEM_HAS_TO_BE_REFRIGERATED,
            ITEM_IMAGE_PATH
          ) VALUES (
            ${nameof(item.Name)},
            ${nameof(item.Description)},
            ${nameof(item.ItemType)},
            ${nameof(item.LocationType)},
            ${nameof(item.Quantity)},
            ${nameof(item.ExpirationDate)},
            ${nameof(item.HasToBeRefrigerated)},
            ${nameof(item.ImagePath)}
          );";

        command.Parameters.AddWithValue($"${nameof(item.Name)}", item.Name);
        command.Parameters.AddWithValue($"${nameof(item.Description)}", item.Description);
        command.Parameters.AddWithValue($"${nameof(item.ItemType)}", (int)item.ItemType);
        command.Parameters.AddWithValue($"${nameof(item.LocationType)}", (int)item.LocationType);
        command.Parameters.AddWithValue($"${nameof(item.Quantity)}", item.Quantity);
        command.Parameters.AddWithValue($"${nameof(item.ExpirationDate)}", item.ExpirationDate?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
        command.Parameters.AddWithValue($"${nameof(item.HasToBeRefrigerated)}", item.HasToBeRefrigerated);
        command.Parameters.AddWithValue($"${nameof(item.ImagePath)}", string.IsNullOrEmpty(item.ImagePath) ? DBNull.Value : item.ImagePath);

        try
        {
          command.ExecuteNonQuery();
          return true;
        }
        catch (SqliteException e)
        {
          Debug.WriteLine($"An error occurred: {e.Message}");
          return false;
        }
        finally
        {
          connection.Close();
        }
      }
    }

    /// <summary>
    /// Removes an item from the database
    /// </summary>
    public bool Remove(int id)
    {
      using (var connection = new SqliteConnection(Settings.ConnectionString))
      {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = $"DELETE FROM ND_ITEMS WHERE ITEM_ID = ${nameof(id)};";

        command.Parameters.AddWithValue($"${nameof(id)}", id);

        try
        {
          command.ExecuteNonQuery();
          return true;
        }
        catch (SqliteException e)
        {
          Debug.WriteLine($"An error occurred: {e.Message}");
          return false;
        }
        finally
        {
          connection.Close();
        }
      }
    }
  }
}
