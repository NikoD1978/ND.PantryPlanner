using ND.PantryPlanner.MAUI.Views;

namespace ND.PantryPlanner.MAUI
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      MainPage = new AppShell();
    }
  }
}
