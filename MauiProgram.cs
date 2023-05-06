using Messenger_App.View;
using Messenger_App.ViewModel;
using Microsoft.Extensions.Logging;

namespace Messenger_App;

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

		builder.Services.AddTransient<DialogViewModel>();
		builder.Services.AddTransient<DialogPage>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
