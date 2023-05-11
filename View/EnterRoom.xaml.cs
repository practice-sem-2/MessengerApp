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
            if (ex is HttpRequestException && Convert.ToInt32((ex as HttpRequestException).StatusCode) == 400)
            {

                HttpRequestMessage reRequest = new(HttpMethod.Post, $"http://{App.IP}:6969/rooms/{roomNameEntry.Text}/join");
                reRequest.Headers.Add("accept", "application/json");
                reRequest.Headers.Add("Authorization", $"Bearer {User.ThisUserToken}");
                try
                {
                    HttpResponseMessage response = await client.SendAsync(reRequest);
                    response.EnsureSuccessStatusCode();
                }
                catch(Exception exe) 
                {
                    if (exe.Message.Split("\"").Length >= 4 && exe.Message.Split("\"")[3] != "User already in room")
                    { }
                }
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