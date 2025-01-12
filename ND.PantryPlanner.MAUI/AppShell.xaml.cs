using ND.PantryPlanner.MAUI.Views;

namespace ND.PantryPlanner.MAUI
{
  public partial class AppShell : Shell
  {
    public AppShell()
    {
      InitializeComponent();

      Routing.RegisterRoute(nameof(AddItem), typeof(AddItem));
      Routing.RegisterRoute(nameof(EditItem), typeof(EditItem));
    }
  }
}
