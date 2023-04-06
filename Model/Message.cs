
namespace Messenger_App.Model
{
    internal class Message
    {
        public Message(string text, User sentBy)
        {
            _messageText= text;
            _sentBy= sentBy;
        }

        private string _messageText;

        public string MessageText 
        { 
            get => _messageText;
            set
            {
                _messageText = value;
                _isEdited = true;
            } 
        }

        public bool IsEdited { get; }
        internal User SentBy { get; }

        private bool _isEdited = false;

        private User _sentBy;
    }
}
