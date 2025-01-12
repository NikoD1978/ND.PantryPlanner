using Microsoft.Extensions.Logging;

using ND.PantryPlanner.Common.Interfaces;
using ND.PantryPlanner.DataLayer.Initialization;
using ND.PantryPlanner.DataLayer.Repositories;
using ND.PantryPlanner.MAUI.Commands;
using ND.PantryPlanner.MAUI.Views;
using ND.PantryPlanner.ModelLayer.Models;
using ND.PantryPlanner.ViewModelLayer.ViewModels;

namespace ND.PantryPlanner.MAUI
{
  /// <summary>
  /// Main entry point for the application
  /// </summary>
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      // Initialize the database, create a database file if it doesn't exist
      var database = new DatabaseInitializer();
      database.Initialize();

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

      // DI Services (Repositories)
      builder.Services.AddTransient<IRepository<Item>, ItemRepository>();

      // DI Services (Commands)
      builder.Services.AddSingleton<ItemViewModelCommands>();

      // DI Services (ViewModels)
      builder.Services.AddSingleton<ItemViewModel>();

      // DI Services (Views)
      builder.Services.AddTransient<MainPage>();
      builder.Services.AddTransient<AddItem>();

      return builder.Build();
    }
  }
}
