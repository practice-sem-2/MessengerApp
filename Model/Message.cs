
namespace Messenger_App.Model
{
    internal class Message
    {
        public Message(string text, User sentBy)
        {
            MessageText = text;
            _sentBy= sentBy;
        }

        public string MessageText 
        {
            get;
        }

        internal User SentBy { get => _sentBy; }


        private User _sentBy;
    }
}
