﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger_App.Model
{
    internal class User
    {
        static public string ThisUser = "GalTeXx";
        public string UserName { get; }   
        public Image ProfilePicture { get; }

        public User(string username)
        {
            UserName = username;
            //ProfilePicture = profilePicture;
        }
    }
}