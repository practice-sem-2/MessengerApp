using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger_App.Model
{
    internal class User
    {
        public string Name { get; }   
        public string Surname { get; }   
        public string ChatID { get; }

        public Image ProfilePicture { get; }

        public User(string name, string surname, string chatID)
        {
            Name = name;
            Surname = surname;
            ChatID = chatID;
            //ProfilePicture = profilePicture;
        }
    }
}
