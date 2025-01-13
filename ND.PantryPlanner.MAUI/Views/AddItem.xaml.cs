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

    //void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    //{
    //  var picker = (Picker)sender;
    //  int selectedIndex = picker.SelectedIndex;

    //  if (selectedIndex != -1)
    //  {
    //    ViewModel.ItemObject.ItemTypeString = picker.Items[selectedIndex];
    //  }
    //}
  }
}