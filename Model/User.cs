using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger_App.Model
{
    public class User
    {
        static public string ThisUserName = null;
        static public string ThisUserToken = null;
        public string UserName { get; }   
        public Image ProfilePicture { get; }

        public User(string username)
        {
            UserName = username;
            //ProfilePicture = profilePicture;
        }
    }
}
