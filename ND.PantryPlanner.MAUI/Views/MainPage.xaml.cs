using ND.PantryPlanner.ViewModelLayer.ViewModels;

namespace ND.PantryPlanner.MAUI.Views
{
  public partial class MainPage : ContentPage
  {
    /// <summary>
    /// The view model for the main page
    /// </summary>
    private readonly ItemViewModel _viewModel;

    int count = 0;

    public MainPage(ItemViewModel viewModel)
    {
      BindingContext = viewModel;
      _viewModel = viewModel;
      InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
      count++;

      if (count == 1)
        CounterBtn.Text = $"Clicked {count} time";
      else
        CounterBtn.Text = $"Clicked {count} times";

      SemanticScreenReader.Announce(CounterBtn.Text);
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
