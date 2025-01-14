using ND.PantryPlanner.MAUI.Resources.Localization;
using ND.PantryPlanner.MAUI.Views;
using System.Globalization;

namespace ND.PantryPlanner.MAUI
{
  public partial class App : Application
  {
    public App()
    {
      Application.Current.UserAppTheme = AppTheme.Light;

      var culture = new CultureInfo("de-DE");
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;

      // Set the culture for the application resources
      AppResources.Culture = culture;

      InitializeComponent();

      MainPage = new AppShell();
    }
  }
}
