using ND.PantryPlanner.MAUI.Commands;
using ND.PantryPlanner.ModelLayer.Enums;

namespace ND.PantryPlanner.MAUI.Views
{
	public partial class AddItem : ContentPage
	{
    public ItemViewModelCommands ViewModel;

    public AddItem(ItemViewModelCommands viewModel)
		{
      InitializeComponent();

      ViewModel = viewModel;
		}

    protected override void OnAppearing()
    {
      base.OnAppearing();

      BindingContext = ViewModel;
      ViewModel.GetItemTypes();
      ViewModel.Get();
    }
  }
}