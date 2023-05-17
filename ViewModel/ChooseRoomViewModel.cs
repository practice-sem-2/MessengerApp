using Android.Util;
using Messenger_App.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Messenger_App.ViewModel
{
    internal class ChooseRoomViewModel : INotifyPropertyChanged
    {
        private HttpClient client;

        public ObservableCollection<Room> RoomsCollection { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ChooseRoomViewModel() 
        {
            client = new();
            RoomsCollection = new();
            ReciveData();
        }

        private async void ReciveData()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:6969/rooms");

            request.Headers.Add("accept", "application/json");
            request.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE2ODQzNDMxMjMsIm5iZiI6MTY4NDM0MzEyMywiZXhwIjoxNjg1NTUyNzIzLCJzdWIiOiJnIn0.xYhiRcPeyODw0LNzsKDSa3VsPov6dk8M9lNfGdDv8PA");
            string responseBody = "";
            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                return;
            }
            catch (Exception ex)
            {

            }
            RoomsCollection = JsonSerializer.Deserialize<ObservableCollection<Room>>(responseBody);
        }
    }
}
