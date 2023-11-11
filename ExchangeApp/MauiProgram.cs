using CommunityToolkit.Maui;
using ExchangeApp.Core.Services;
using ExchangeApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace ExchangeApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddTransient<ExchangesViewModel>();

            builder.Services.AddSingleton<IExchangeService, ExchangeService>(x => 
                ActivatorUtilities.CreateInstance<ExchangeService>(x, $"{Path.Combine(FileSystem.AppDataDirectory, "ExchangeApp.db")};"));

            return builder.Build();
        }
    }
}
