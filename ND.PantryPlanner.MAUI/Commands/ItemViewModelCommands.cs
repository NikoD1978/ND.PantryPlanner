using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using ND.PantryPlanner.Common.Interfaces;
using ND.PantryPlanner.DataLayer.Repositories;
using ND.PantryPlanner.ModelLayer.Enums;
using ND.PantryPlanner.ModelLayer.Models;
using ND.PantryPlanner.ViewModelLayer.ViewModels;

namespace ND.PantryPlanner.MAUI.Commands
{
  public class ItemViewModelCommands : ItemViewModel
  {
    public ItemViewModelCommands() : base() => Init();

    public ItemViewModelCommands(IRepository<Item> repository) : base(repository) => Init();

    public ItemViewModelCommands(IRepository<Item> repository, IRepository<string> itemTypeRepository) : base(repository, itemTypeRepository) => Init();

    private bool _isSaveButtonEnabled = false;
    public bool IsSaveButtonEnabled
    {
      get { return _isSaveButtonEnabled; }
      set
      {
        _isSaveButtonEnabled = value;
        OnPropertyChanged(nameof(IsSaveButtonEnabled));
        ((Command)AddItemCommand).ChangeCanExecute();
        ((Command)UpdateItemCommand).ChangeCanExecute();
      }
    }

    //private bool _isAddItemCommandEnabled = false;
    //public bool IsAddItemCommandEnabled
    //{
    //  get { return _isAddItemCommandEnabled; }
    //  set
    //  {
    //    _isAddItemCommandEnabled = value;
    //    OnPropertyChanged(nameof(IsAddItemCommandEnabled));
    //    ((Command)AddItemCommand).ChangeCanExecute();
    //  }
    //}

    //private bool _isUpdateItemCommandEnabled = false;
    //public bool IsUpdateItemCommandEnabled
    //{
    //  get { return _isUpdateItemCommandEnabled; }
    //  set
    //  {
    //    _isUpdateItemCommandEnabled = value;
    //    OnPropertyChanged(nameof(IsUpdateItemCommandEnabled));
    //    ((Command)UpdateItemCommand).ChangeCanExecute();
    //  }
    //}

    public ICommand ShowAddItemCommand { get; private set; }
    public ICommand ShowEditItemCommand { get; private set; }
    public ICommand AddItemCommand { get; private set; }
    public ICommand UpdateItemCommand { get; private set; }
    public ICommand DeleteItemCommand { get; private set; }
    public ICommand CancelCommand { get; private set; }

    /// <summary>
    /// Initializes the view model
    /// </summary>
    public override void Init()
    {
      base.Init();

      // Create commands for this view
      ShowAddItemCommand = new Command(async () => await ShowAddItemAsync());
      ShowEditItemCommand = new Command<int>(async (int id) => await ShowEditItemAsync(id), (id) => true);
      AddItemCommand = new Command(async () => await AddItemAsync(), () => IsSaveButtonEnabled);
      UpdateItemCommand = new Command(async () => await UpdateItemAsync(), () => IsSaveButtonEnabled);
      DeleteItemCommand = new Command<int>(async (int id) => await DeleteItemAsync(id), (id) => true);
      CancelCommand = new Command(async () => await CancelAsync());
    }

    private void ItemObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      ValidateItem();
    }

    /// <summary>
    /// Validates the current item to determine if the Save button should be enabled
    /// </summary>
    private void ValidateItem()
    {
      IsSaveButtonEnabled = !string.IsNullOrWhiteSpace(ItemObject.Name) &&
                            !string.IsNullOrWhiteSpace(ItemObject.Description) &&
                            ItemObject.ItemType != ItemType.None &&
                            ItemObject.Quantity > 0;
    }

    /// <summary>
    /// Shows the Add Item page
    /// </summary>
    public async Task ShowAddItemAsync()
    {
      ItemObject = new Item();
      ItemObject.ItemTypeString = ItemTypesList[0];

      ItemObject.PropertyChanged += ItemObject_PropertyChanged;

      await Shell.Current.GoToAsync($"{nameof(Views.AddItem)}");
    }

    /// <summary>
    /// Shows the Edit Item page
    /// </summary>
    public async Task ShowEditItemAsync(int id)
    {
      ItemObject = Get(id);

      ItemObject.OnPropertyChanged(nameof(ItemObject.Name));
      ItemObject.OnPropertyChanged(nameof(ItemObject.Description));
      ItemObject.OnPropertyChanged(nameof(ItemObject.ItemType));
      ItemObject.OnPropertyChanged(nameof(ItemObject.Quantity));

      ItemObject.PropertyChanged += ItemObject_PropertyChanged;

      await Shell.Current.GoToAsync($"{nameof(Views.EditItem)}?id={id}");
    }

    /// <summary>
    /// Adds the current item to the repository
    /// </summary>
    public async Task<bool> AddItemAsync()
    {
      var result = base.AddCurrentItem();

      if (result)
      {
        await Shell.Current.GoToAsync("../..");
      }
      else
      {
        await Application.Current.MainPage.DisplayAlert("Error", "Failed to add the item.", "OK");
      }

      return result;
    }

    /// <summary>
    /// Updates the current item in the repository
    /// </summary>
    public async Task<bool> UpdateItemAsync()
    {
      var result = base.UpdateCurrentItem();
      
      if (result)
      {
        await Shell.Current.GoToAsync("../..");
      }
      else
      {
        await Application.Current.MainPage.DisplayAlert("Error", "Failed to update the item.", "OK");
      }

      return result;
    }

    /// <summary>
    /// Cancels the current operation and navigates back to the previous page
    /// </summary>
    public async Task CancelAsync()
    {
      await Shell.Current.GoToAsync("../..");
    }

    /// <summary>
    /// Deletes the item with this ID from the repository
    /// </summary>
    public async Task DeleteItemAsync(int id)
    {
      var result = await Application.Current.MainPage.DisplayAlert("Delete Item", "Are you sure you want to delete this item?", "Yes", "No");
      if (result)
      {
        if (base.Delete(id))
        {
          Get();
          await Shell.Current.GoToAsync("..");
        }
        else
        {
          await Application.Current.MainPage.DisplayAlert("Error", "Failed to delete the item.", "OK");
        }
      }
    }
  }
}
