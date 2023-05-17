using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger_App.Model
{
    internal class Room
    {
        private int members_count;
        private string name;

        public int AmountOfUsers { get => members_count; set => members_count = value; }
        public string Name { get => name; set => name = value; }

        public Room(string name, int amountOfUsers)
        {
            Name = name;
            AmountOfUsers = amountOfUsers;
        }
    }
}
