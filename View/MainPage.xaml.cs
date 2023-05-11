using Messenger_App.Model;
using Messenger_App.ViewModel;
using System.Net.Http.Headers;
namespace Messenger_App.View;

public partial class MainPage : ContentPage
{

	private readonly HttpClient client = new();

    public MainPage()
	{
		InitializeComponent();
		BindingContext = new DialogViewModel();
	}

    private async void Enter_Button_Clicked(object sender, EventArgs e)
    {
        string mode = singInRadioButton.IsChecked ? "in" : "up";
        HttpRequestMessage request = new(HttpMethod.Post, $"http://{App.IP}:6969/auth/sign-{mode}");

        request.Headers.Add("accept", "application/json");

        request.Content = new StringContent($"grant_type=&username={loginEntry.Text}&password={passwordEntry.Text}&scope=&client_id=&client_secret=");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        string responseBody;
        try
        {
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
        }
        catch (Exception) 
        {
            statusLabel.Text = "Something went wrong!";
            return;
        }
        if (!singInRadioButton.IsChecked)
            return;
		User.ThisUserName = loginEntry.Text;
        User.ThisUserToken = responseBody.Split("\"")[3];
        if(User.ThisUserToken == null)
        {
            statusLabel.Text = "Something went wrong!";
            return;
        }
        await Shell.Current.GoToAsync(nameof(EnterRoom), true);
    }
}