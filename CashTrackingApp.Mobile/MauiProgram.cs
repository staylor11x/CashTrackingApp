using CashTrackingApp.Mobile.Repository;
using CashTrackingApp.Mobile.Service;
using CashTrackingApp.Mobile.View;
using CashTrackingApp.Mobile.ViewModel;
using Microsoft.Extensions.Logging;

namespace CashTrackingApp.Mobile;

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

        //Register the service so you dont have to instansiate later
        builder.Services.AddSingleton<ICashRepository, CashRepository>();
        builder.Services.AddSingleton<ICashService, CashService>();
        builder.Services.AddTransient<CashViewModel>();

        //Register the page(s) for DI
        builder.Services.AddTransient<CashBalancePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
