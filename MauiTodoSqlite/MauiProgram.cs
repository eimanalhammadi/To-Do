using MauiTodoSqlite.Data;
using MauiTodoSqlite.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiTodoSqlite
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
            builder.Services.AddSingleton<TaskRepository>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<NewTaskViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<NewTaskPage>();
            builder.Services.AddSingleton<AppShell>;
            return builder.Build();
        }
    }
}
