using MauiMathGame.Data;
using Microsoft.Extensions.Logging;

namespace MauiMathGame
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

            //#if DEBUG
            //    		builder.Logging.AddDebug();
            //#endif
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "game.db");

            // Register GameRepository so it can be injected
            builder.Services.AddSingleton(s =>
                ActivatorUtilities.CreateInstance<GameRepository>(s, dbPath));

            return builder.Build();
        }
    }
}
