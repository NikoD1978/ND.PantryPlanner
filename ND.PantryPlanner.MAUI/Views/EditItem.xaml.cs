using ND.PantryPlanner.MAUI.Commands;

namespace ND.PantryPlanner.MAUI.Views;

public partial class EditItem : ContentPage
{
  public ItemViewModelCommands ViewModel;

  public EditItem(ItemViewModelCommands viewModel)
	{
		InitializeComponent();

    ViewModel = viewModel;
  }

  protected override void OnAppearing()
  {
    base.OnAppearing();
    
    BindingContext = ViewModel;
    ViewModel.Get();
    ViewModel.GetItemTypes();
  }
}