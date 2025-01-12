﻿using System.Collections.ObjectModel;

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
    /// Gets the current list of items
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

    public ObservableCollection<string> ItemTypesList
    {
      get { return _itemTypesList; }
      set
      {
        _itemTypesList = value;
        OnPropertyChanged();
      }
    }

    public Item ItemObject
    {
      get { return _itemObject; }
      set
      {
        _itemObject = value;
        OnPropertyChanged();
      }
    }

    public ObservableCollection<Item> Get()
    {
      if (Repository != null)
      {
        ItemList = new ObservableCollection<Item>(Repository.Get());
      }

      return ItemList;
    }

    public Item Get(int id)
    {
      if (Repository != null)
      {
        ItemObject = Repository.Get(id);
      }

      return ItemObject;
    }

    public virtual bool Save()
    {
      return Repository.Add(ItemObject);
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
