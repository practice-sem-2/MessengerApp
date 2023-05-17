using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming
namespace Messenger_App.Model
{
    internal class Room
    {
        private int _members_count;
        private string _name;

        //gotta love how JSON serializer makes me ruin my own naming
        public string name { get => _name; set => _name = value; }

        public int members_count { get => _members_count; set => _members_count = value; }

        public Room(string name, int members_count)
        {
            _name = name;
            _members_count = members_count;
        }
    }
#pragma warning restore IDE1006 // Naming
}
