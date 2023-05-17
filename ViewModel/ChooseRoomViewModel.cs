using Messenger_App.Model;
using Messenger_App.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;

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

        public ChooseRoomViewModel() 
        {
            client = new();
            RoomsCollection = Task.Run(ReciveData).Result;
        }

        public ICommand JoinRoom => new Command<string>(JoinRoomCommand);

        private async void JoinRoomCommand(string roomname)
        {
            await Shell.Current.GoToAsync($"{nameof(DialogPage)}?RoomName={roomname}");
        }

        private async Task<ObservableCollection<Room>> ReciveData()
        {
            HttpRequestMessage request = new(HttpMethod.Get, $"http://{App.IP}:6969/rooms");

            request.Headers.Add("accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {User.ThisUserToken}");
            string responseBody = "";
            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                
            }
            return JsonSerializer.Deserialize<ObservableCollection<Room>>(responseBody);
        }
    }
}
