using System.Windows.Input;

using ND.PantryPlanner.Common.Interfaces;
using ND.PantryPlanner.ModelLayer.Models;
using ND.PantryPlanner.ViewModelLayer.ViewModels;

namespace ND.PantryPlanner.MAUI.Commands
{
  public class ItemViewModelCommands : ItemViewModel
  {
    public ItemViewModelCommands() : base() => Init();

    public ItemViewModelCommands(IRepository<Item> repository) : base(repository) => Init();

    public ICommand ShowAddItemCommand { get; private set; }
    public ICommand ShowEditItemCommand { get; private set; }
    public ICommand SaveItemCommand { get; private set; }
    public ICommand DeleteItemCommand { get; private set; }
    public ICommand CancelCommand { get; private set; }

    public override void Init()
    {
      base.Init();
      GetItemTypes();
      
      // Create commands for this view
      ShowAddItemCommand = new Command(async () => await ShowAddItemAsync());
      ShowEditItemCommand = new Command<int>(async (int id) => await ShowEditItemAsync(id), (id) => true);
      SaveItemCommand = new Command(async () => await SaveItemAsync());
      DeleteItemCommand = new Command<int>(async (int id) => await DeleteItemAsync(id), (id) => true);
      CancelCommand = new Command(async () => await CancelAsync());
    }

    /// <summary>
    /// Shows the Add Item page
    /// </summary>
    public async Task ShowAddItemAsync()
    {
      ItemObject = new Item();

      await Shell.Current.GoToAsync($"{nameof(Views.AddItem)}");
    }

    public async Task ShowEditItemAsync(int id)
    {
      await Shell.Current.GoToAsync($"{nameof(Views.EditItem)}?id={id}");
    }

    public async Task<bool> SaveItemAsync()
    {
      var result = base.Save();

      if (result)
      {
        await Shell.Current.GoToAsync("..");
      }

      return result;
    }

    public async Task CancelAsync()
    {
      await Shell.Current.GoToAsync("..");
    }

    public async Task DeleteItemAsync(int id)
    {
      var result = await Application.Current.MainPage.DisplayAlert("Delete Item", "Are you sure you want to delete this item?", "Yes", "No");
      if (result)
      {
        if (base.Delete(id))
        {
          // Send a message to notify that the item has been deleted
          MessagingCenter.Send(this, "ItemDeleted");
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
