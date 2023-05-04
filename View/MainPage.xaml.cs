using Messenger_App.ViewModel;

namespace Messenger_App.View;

public partial class MainPage : ContentPage
{
    
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new DialogViewModel();
	}
}