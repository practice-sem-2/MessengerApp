namespace Messenger_App;

public partial class App : Application
{
	public static readonly string IP = "77.37.200.25";
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
