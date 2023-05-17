using Messenger_App.Model;
using System.Net.Http.Headers;

namespace Messenger_App.View;


public partial class EnterRoom : ContentPage
{
    //Yes, I am aware of possible socket exhaustion. However this scenario is VERY unlikely
    private readonly HttpClient client = new();
	public EnterRoom()
	{
		InitializeComponent();
	}

    private async void EnterRoom_Button_Clicked(object sender, EventArgs e)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"http://{App.IP}:6969/rooms/{roomNameEntry.Text}/");
        request.Headers.Add("accept", "application/json");
        request.Headers.Add("Authorization", $"Bearer {User.ThisUserToken}");
        request.Content = new StringContent("");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded"); 
        try
        {
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            if (Convert.ToInt32((ex as HttpRequestException).StatusCode.Value) == 400)
            {
                statusLabel.Text = $"Room {roomNameEntry.Text} allready exists";
                return;
            }
            else
            {
                statusLabel.Text = "Failed to create new room!";
                return;
            }
        }
            await Shell.Current.GoToAsync($"{nameof(DialogPage)}?RoomName={roomNameEntry.Text}", true);
    }
}