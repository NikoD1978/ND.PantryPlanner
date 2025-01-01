using System.Collections.ObjectModel;

using ND.PantryPlanner.Common.BaseClasses;
using ND.PantryPlanner.Common.Interfaces;
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
    }
  }
}
