using Messenger_App.View;

namespace Messenger_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(mainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(DialogPage), typeof(DialogPage));

	}
}
