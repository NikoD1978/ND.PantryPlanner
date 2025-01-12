using ND.PantryPlanner.MAUI.Commands;

namespace ND.PantryPlanner.MAUI.Views;

[QueryProperty(nameof(ItemId), "id")]
public partial class EditItem : ContentPage
{
  public ItemViewModelCommands ViewModel;
  public int ItemId { get; set; }

  public EditItem()
  {
    InitializeComponent();

    ViewModel = new ItemViewModelCommands();
  }

  public EditItem(ItemViewModelCommands viewModel)
	{
		InitializeComponent();

    ViewModel = viewModel;
  }

  protected override void OnAppearing()
  {
    base.OnAppearing();
    
    BindingContext = ViewModel;
    ViewModel.GetItemTypes();
    ViewModel.Get(ItemId);
  }
}