using Messenger_App.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Windows.Input;


//comented everything cuz i was getting a headace by looking at thes
namespace Messenger_App.ViewModel
{
    [QueryProperty("RoomName", "RoomName")]
    public class DialogViewModel : INotifyPropertyChanged
    {
        private ClientWebSocket ws = new();
        //I wish .Net had Unity-like coroutines
        private Progress<string> recivedMessage;

        public ObservableCollection<Message> MessagesCollection { get; set; }

        private readonly HttpClient _client = new();

        private string _roomName;
        public string RoomName
        {
            get => _roomName;
            set
            {
                _roomName = value;
                OnPropertyChanged(nameof(RoomName));
                recivedMessage = new(FormatRecivedJsonIntoMessage);
                Task.Run(() => ListenToMessages(recivedMessage));
            }
        }

        public DialogViewModel()
        {
            MessagesCollection = new();
            recivedMessage = new(FormatRecivedJsonIntoMessage);
        }


        private async void ListenToMessages(IProgress<string> prog)
        {
            try
            {
                //Due to Maui reasons, constructor also gets called at the very start of the app
                await ws.ConnectAsync(new Uri($"ws://{App.IP}:6969/rooms/{RoomName}/events/listen?access_token={User.ThisUserToken}"), CancellationToken.None);
            }
            catch (Exception ex)
            {
                //report socket creation failiure
                MessagesCollection.Add(new Message($"{ex.Message}", new User("System")));
            }

            while (ws.State == WebSocketState.Open)
            {
                //read socket
                byte[] reciveBuffer = new byte[2048];
                WebSocketReceiveResult result = await ws.ReceiveAsync(reciveBuffer, CancellationToken.None);
                prog.Report(Encoding.UTF8.GetString(reciveBuffer, 0, result.Count));
            }
        }


        private void FormatRecivedJsonIntoMessage(string wsResult)
        {
            //it is 4-6 hrs before deadline and i am NOT going to parse JSONs as intended
            if (wsResult.Split("\"").Length < 4)
                return;
            if (wsResult.Split("\"")[3] == "user_connected")
            {
                MessagesCollection.Add(new Message($"You joined this room", new User("System")));
            }
            else if (wsResult.Split("\"")[3] == "new_message")
            {
                if (wsResult.Split("\"")[11] != User.ThisUserName)
                {
                    MessagesCollection.Add(new Message(wsResult.Split("\"")[15], new User(wsResult.Split("\"")[11])));
                }
            }
            else if (wsResult.Split("\"")[3] == "user_joined")
            {
                MessagesCollection.Add(new Message($"{wsResult.Split("\"")[7]} joined this room ", new User("System")));
            }
            else if(wsResult.Split("\"")[3] == "user_disconnected")
                MessagesCollection.Add(new Message($"{wsResult.Split("\"")[7]} left the room", new User("System")));
            else
                MessagesCollection.Add(new Message(wsResult, new User("System")));
        }


        private async void SendMessageMethod(string messageText)
        {
            //creating new request
            var message = new Message(messageText, new User(User.ThisUserName));
            HttpRequestMessage request = new(HttpMethod.Post, $"http://{App.IP}:6969/rooms/{RoomName}/messages/send?text={messageText}");
            request.Headers.Add("accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {User.ThisUserToken}");
            request.Content = new StringContent("");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            //attempt to send new request
            try
            {
                HttpResponseMessage response = await _client.SendAsync(request);
                string responseBody = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
            }
            catch(Exception ex) {
            //atempt to send message failed
                message.MessageText = "This message could not be sent.";
                message.SenderName = "System";
            }
            //display message no matter what
            MessagesCollection.Add(message);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SendMessage => new Command<string>(SendMessageMethod);
        public ICommand EndDialog => new Command(Close);

        private async void Close()
        {
            try
            {
                await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "User Left", CancellationToken.None);
                _client.Dispose();
            }
            catch { }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
