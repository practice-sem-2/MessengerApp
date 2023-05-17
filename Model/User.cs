using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger_App.Model
{
    public class User
    {
        private static string _thisUserName = null;
        private static string _thisUserToken = null;
        public string UserName { get; }   
        public Image ProfilePicture { get; }
        public static string ThisUserName { get => _thisUserName; set => _thisUserName = value; }
        public static string ThisUserToken { get => _thisUserToken; set => _thisUserToken = value; }

        public User(string username)
        {
            UserName = username;
            //ProfilePicture = profilePicture;
        }
    }
}
