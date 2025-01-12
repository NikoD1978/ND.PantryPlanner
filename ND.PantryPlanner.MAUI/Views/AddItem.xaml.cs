using ND.PantryPlanner.MAUI.Commands;

namespace ND.PantryPlanner.MAUI.Views
{
	public partial class AddItem : ContentPage
	{
    private readonly ItemViewModelCommands _viewModel;

    public AddItem(ItemViewModelCommands viewModel)
		{
      InitializeComponent();

      BindingContext = new ItemViewModelCommands();
      _viewModel = viewModel;
		}

    protected override void OnAppearing()
    {
      base.OnAppearing();
      _viewModel.Get();
    }
  }
}