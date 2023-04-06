using Messenger_App.ViewModel;

namespace Messenger_App.View;

public partial class DialogPage : ContentPage
{
	public DialogPage()
	{
		InitializeComponent();
		BindingContext = new DialogViewModel();
	}
}