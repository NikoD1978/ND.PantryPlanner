using System.Windows.Input;

using ND.PantryPlanner.Common.Interfaces;
using ND.PantryPlanner.ModelLayer.Models;
using ND.PantryPlanner.ViewModelLayer.ViewModels;

namespace ND.PantryPlanner.MAUI.Commands
{
  public class ItemViewModelCommands : ItemViewModel
  {
    public ItemViewModelCommands() : base()
    {
    }

    public ItemViewModelCommands(IRepository<Item> repository) : base(repository)
    {
    }

    public ICommand ShowAddItemCommand { get; private set; }

    public override void Init()
    {
      base.Init();

      // Create commands for this view
      ShowAddItemCommand = new Command<int>(async (int id) => await ShowAddItemAsync(id), (id) => true);
    }

    protected async Task ShowAddItemAsync(int id)
    {
      await Shell.Current.GoToAsync($"{nameof(Views.MainPage)}?id={id}");
    }
  }
}
