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

    public override void Init()
    {
      base.Init();

      // Create commands for this view
      //ShowAddItemCommand = new Command<int>(async (int id) => await ShowAddItemAsync(id), (id) => true);
      ShowAddItemCommand = new Command(async () => await ShowAddItemAsync());
      SaveItemCommand = new Command(async () => await SaveItemAsync());
    }

    /// <summary>
    /// Shows the Add Item page
    /// </summary>
    private async Task ShowAddItemAsync()
    {
      await Shell.Current.GoToAsync($"{nameof(Views.AddItem)}");
    }

    private async Task ShowEditItemAsync(int id)
    {
      await Shell.Current.GoToAsync($"{nameof(Views.EditItem)}?id={id}");
    }

    private async Task<bool> SaveItemAsync()
    {
      var result = base.Save();

      if (result)
      {
        await Shell.Current.GoToAsync("..");
      }

      return result;
    }
  }
}
