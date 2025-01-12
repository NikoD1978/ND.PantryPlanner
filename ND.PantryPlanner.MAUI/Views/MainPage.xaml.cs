using ND.PantryPlanner.MAUI.Commands;
using ND.PantryPlanner.ViewModelLayer.ViewModels;

namespace ND.PantryPlanner.MAUI.Views
{
  public partial class MainPage : ContentPage
  {
    /// <summary>
    /// The view model for the main page
    /// </summary>
    private readonly ItemViewModelCommands _viewModel;

    public MainPage(ItemViewModelCommands viewModel)
    {
      InitializeComponent();

      BindingContext = new ItemViewModelCommands();
      _viewModel = viewModel;
    }

    /// <summary>
    /// When the page appears, get the list of items
    /// </summary>
    protected override void OnAppearing()
    {
      base.OnAppearing();
      _viewModel.Get();
    }
  }
}
