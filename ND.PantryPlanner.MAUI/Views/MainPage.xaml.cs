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

      MessagingCenter.Subscribe<ItemViewModelCommands>(this, "ItemDeleted", async (sender) =>
      {
        // Refresh the data on the main page
        await RefreshDataAsync();
      });
    }

    private async Task RefreshDataAsync()
    {
      // Reloading the item list from the repository
      var viewModel = BindingContext as ItemViewModel;
      if (viewModel != null)
      {
        viewModel.ItemList = viewModel.Get();
      }
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

    protected override void OnDisappearing()
    {
      base.OnDisappearing();
      // Unsubscribe from the message to avoid memory leaks
      MessagingCenter.Unsubscribe<ItemViewModelCommands>(this, "ItemDeleted");
    }
  }
}
