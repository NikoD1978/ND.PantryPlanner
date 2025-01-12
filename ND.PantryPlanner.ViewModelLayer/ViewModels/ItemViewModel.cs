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
      _repository = null!; // "Forgives" null value; avoids warning CS8618
      _itemList = new ObservableCollection<Item>();
    }

    /// <summary>
    /// Constructor for the ItemViewModel
    /// </summary>
    public ItemViewModel(IRepository<Item> repository) : base()
    {
      _repository = repository;
      _itemList = new ObservableCollection<Item>();
    }

    private readonly IRepository<Item> _repository;
    private ObservableCollection<Item> _itemList;
    private ObservableCollection<string> _itemTypesList = new();
    private Item _item;

    /// <summary>
    /// Gets the current list of items
    /// </summary>
    public ObservableCollection<Item> ItemList
    {
      get
      {
        if (_itemList == null)
        {
          _itemList = _repository.Get();
        }
        return _itemList;
      }
      set
      {
        _itemList = value;
        OnPropertyChanged();
      }
    }

    public ObservableCollection<string> ItemTypesList
    {
      get { return _itemTypesList; }
      set
      {
        _itemTypesList = value;
        OnPropertyChanged();
      }
    }

    public Item Item
    {
      get
      {
        return _item;
      }
      set
      {
        _item = value;
        OnPropertyChanged();
      }
    }

    public ObservableCollection<Item> Get()
    {
      if (_repository != null)
      {
        _itemList = new ObservableCollection<Item>(_repository.Get());
      }

      return _itemList;
    }

    public Item Get(int id)
    {
      if (_repository != null)
      {
        Item = _repository.Get(id);
      }

      return Item;
    }

    public virtual bool Save()
    {
      return false;
    }

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
