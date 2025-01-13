using ND.PantryPlanner.MAUI.Commands;
using ND.PantryPlanner.ViewModelLayer.ViewModels;

namespace ND.PantryPlanner.MAUI.Views
{
  public partial class MainPage : ContentPage
  {
    /// <summary>
    /// The view model for the main page
    /// </summary>
    public ItemViewModelCommands ViewModel;

    public MainPage(ItemViewModelCommands viewModel)
    {
      InitializeComponent();

      ViewModel = viewModel;
    }

    /// <summary>
    /// When the page appears, get the list of items
    /// </summary>
    protected override void OnAppearing()
    {
      base.OnAppearing();

      BindingContext = ViewModel;
      ViewModel.Get();
      ViewModel.GetItemTypes();
    }
  }
}
