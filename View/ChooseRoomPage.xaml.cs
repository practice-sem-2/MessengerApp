using Messenger_App.Model;
using Messenger_App.ViewModel;
using System.Net.Http.Headers;

namespace Messenger_App.View;

public partial class ChooseRoomPage : ContentPage
{
	HttpClient client;
	public ChooseRoomPage()
	{
		InitializeComponent();
		client = new();
		BindingContext = new ChooseRoomViewModel();
	}

	private async void NewRoom_Button_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(EnterRoom));
	}

    private async void JoinRoom_Button_Clicked(object sender, EventArgs e)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"http://{App.IP}:6969/rooms/{roomNameEntry.Text}/join/");

        request.Headers.Add("accept", "application/json");
        request.Headers.Add("Authorization", $"Bearer {User.ThisUserToken}");

        request.Content = new StringContent("");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

        try
        {
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            
        }
        catch
        {
            roomNameEntry.Text = "";
            roomNameEntry.Placeholder = "Something went wrong!";
        }
        (BindingContext as ChooseRoomViewModel).RefreshRoomsCollection.Execute(null);
    }
}