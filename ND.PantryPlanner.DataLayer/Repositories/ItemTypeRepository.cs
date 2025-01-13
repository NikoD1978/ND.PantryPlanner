using System.Collections.ObjectModel;

using ND.PantryPlanner.Common.Interfaces;
using ND.PantryPlanner.ModelLayer.Enums;

namespace ND.PantryPlanner.DataLayer.Repositories
{
  public class ItemTypeRepository : IRepository<string>
  {
    public bool Add(string entity)
    {
      throw new NotImplementedException();
    }

    public ObservableCollection<string> Get()
    {
      var itemTypesList = new ObservableCollection<string>();

      foreach (var itemType in Enum.GetValues(typeof(ItemType)))
      {
        itemTypesList.Add(itemType.ToString());
      }

      return itemTypesList;
    }

    public string? Get(int id)
    {
      throw new NotImplementedException();
    }

    public bool Remove(int id)
    {
      throw new NotImplementedException();
    }

    public bool Update(string entity)
    {
      throw new NotImplementedException();
    }
  }
}
