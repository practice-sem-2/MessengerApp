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
        public ObservableCollection<Message> MessagesCollection;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SendMessage => new Command<Message>(SendMessageMethod);

        private void SendMessageMethod(Message message)
        {
            MessagesCollection.Add(message);
            //SEND MESSAGE VIA API;

        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
