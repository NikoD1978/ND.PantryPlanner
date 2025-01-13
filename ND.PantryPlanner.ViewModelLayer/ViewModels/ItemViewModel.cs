using System.Collections.ObjectModel;

using ND.PantryPlanner.Common.BaseClasses;
using ND.PantryPlanner.Common.Interfaces;
using ND.PantryPlanner.ModelLayer.Enums;
using ND.PantryPlanner.ModelLayer.Models;

namespace ND.PantryPlanner.ViewModelLayer.ViewModels
{
  /// <summary>
  /// View model for the Item model
  /// </summary>
  public class ItemViewModel : ViewModelBase
  {
    /// <summary>
    /// Default constructor for the ItemViewModel
    /// </summary>
    public ItemViewModel() : base()
    {
    }

    /// <summary>
    /// Constructor for the ItemViewModel
    /// </summary>
    public ItemViewModel(IRepository<Item> repository) : base()
    {
      Repository = repository;
      _itemList = new ObservableCollection<Item>();
    }

    private readonly IRepository<Item> Repository;
    private ObservableCollection<Item> _itemList;
    private ObservableCollection<string> _itemTypesList = new();
    private Item _itemObject;

    /// <summary>
    /// Current list of items
    /// </summary>
    public ObservableCollection<Item> ItemList
    {
      get
      {
        if (_itemList == null)
        {
          _itemList = Repository.Get();
        }
        return _itemList;
      }
      set
      {
        _itemList = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// List of item types
    /// </summary>
    public ObservableCollection<string> ItemTypesList
    {
      get { return _itemTypesList; }
      set
      {
        _itemTypesList = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Current item object
    /// </summary>
    public Item ItemObject
    {
      get { return _itemObject; }
      set
      {
        _itemObject = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Gets the list of items
    /// </summary>
    public ObservableCollection<Item> Get()
    {
      if (Repository != null)
      {
        ItemList = new ObservableCollection<Item>(Repository.Get());
      }

      return ItemList;
    }

    /// <summary>
    /// Gets a single item by its ID
    /// </summary>
    public Item Get(int id)
    {
      if (Repository != null)
      {
        ItemObject = Repository.Get(id);
      }

      return ItemObject;
    }

    /// <summary>
    /// Adds the current item object
    /// </summary>
    public virtual bool AddCurrentItem()
    {
      //ItemObject.ItemType = ItemTypePicker.

      return Repository.Add(ItemObject);
    }

    /// <summary>
    /// Updates the current item object
    /// </summary>
    public virtual bool UpdateCurrentItem()
    {
      return Repository.Update(ItemObject);
    }

    /// <summary>
    /// Deletes an item by its ID
    /// </summary>
    public virtual bool Delete(int id)
    {
      return Repository.Remove(id);
    }

    /// <summary>
    /// Gets the list of item types
    /// </summary>
    public ObservableCollection<string> GetItemTypes()
    {
      ItemTypesList = new ObservableCollection<string>();

      foreach (var itemType in Enum.GetValues(typeof(ItemType)))
      {
        ItemTypesList.Add(itemType.ToString());
      }

      return ItemTypesList;
    }
  }
}
