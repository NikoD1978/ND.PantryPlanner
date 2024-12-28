using Microsoft.Extensions.Logging;

using ND.PantryPlanner.DataLayer.Initialization;

namespace ND.PantryPlanner.MAUI
{
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      var builder = MauiApp.CreateBuilder();
      builder
          .UseMauiApp<App>()
          .ConfigureFonts(fonts =>
          {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
          });

#if DEBUG
      builder.Logging.AddDebug();
#endif

      var database = new DatabaseInitializer();
      database.Initialize();

      return builder.Build();
    }
  }
}
