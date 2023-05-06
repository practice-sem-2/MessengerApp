using Messenger_App.Model;
using Messenger_App.ViewModel;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json.Nodes;

namespace Messenger_App.View;

public partial class MainPage : ContentPage
{

	HttpClient client = new();

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new DialogViewModel();
	}

    private async void Enter_Button_Clicked(object sender, EventArgs e)
    {
		User.ThisUser = loginEntry.Text;

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"http://192.168.1.10:6969/sign-in?username={loginEntry.Text}");

        request.Headers.Add("accept", "application/json");
        request.Content = new StringContent("");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        try
        {
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
        }
        catch (Exception) 
        {
            statusLabel.Text = "somethign went wrong with login!";
            return;
        }

        request = new HttpRequestMessage(HttpMethod.Post, $"http://192.168.1.10:6969/rooms/{RoomNameEntry.Text}/");
        request.Headers.Add("accept", "application/json");
        request.Content = new StringContent("");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        try
        {
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
        }
        catch(Exception ex) 
        {
            statusLabel.Text = "somethign went wrong with the room!";
            return;
        }
        await Shell.Current.GoToAsync($"{nameof(DialogPage)}?RoomName={RoomNameEntry.Text}", true);
    }
}