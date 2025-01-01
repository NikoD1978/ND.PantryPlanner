using Microsoft.Extensions.Logging;

using ND.PantryPlanner.DataLayer.Initialization;

namespace ND.PantryPlanner.MAUI
{
  /// <summary>
  /// Main entry point for the application
  /// </summary>
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

      // Initialize the database, create a database file if it doesn't exist
      var database = new DatabaseInitializer();
      database.Initialize();

      return builder.Build();
    }
  }
}
