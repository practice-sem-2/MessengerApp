using Messenger_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Messenger_App.ViewModel
{
    internal class DialogViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Message> MessagesCollection { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public string dullString { get; } = "heh";

        public ICommand SendMessage => new Command<string>(SendMessageMethod);

        private void SendMessageMethod(string message)
            {
            MessagesCollection.Add(new Message(message, new User("Korsakov", "maxim", "228")));
            //SEND MESSAGE VIA API;

        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DialogViewModel()
        {
            MessagesCollection = new();
        }
    }
}
