using Messenger_App.ViewModel;
namespace Messenger_App.View;

public partial class ChooseRoomPage : ContentPage
{
	public ChooseRoomPage()
	{
		InitializeComponent();
		BindingContext = new ChooseRoomViewModel();
	}

	private async void NewRoom_Button_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(EnterRoom));
	}
}