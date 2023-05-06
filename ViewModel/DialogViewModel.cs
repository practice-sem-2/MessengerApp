using Messenger_App.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Messenger_App.ViewModel
{
    [QueryProperty("RoomName", "RoomName")]
    public class DialogViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Message> MessagesCollection { get; set; }

        private string _roomName;
        public string RoomName
        {
            get => _roomName;
            set
            {
                _roomName = value;
                OnPropertyChanged(nameof(RoomName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SendMessage => new Command<string>(SendMessageMethod);

        private void SendMessageMethod(string message)
        {
            MessagesCollection.Add(new Message(message, new User("GalTeXx")));
            //SEND MESSAGE VIA API;

        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DialogViewModel()
        {
            //GET ALL MESSAGES VIA API
            MessagesCollection = new();
            
        }
    }
}
