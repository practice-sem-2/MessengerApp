
using Messenger_App.View;

namespace Messenger_App.Model
{
    internal class Message
    {
        public static readonly BindableProperty MessageTextProperty = BindableProperty.Create(nameof(MessageText), typeof(string), typeof(Message), string.Empty);
        public static readonly BindableProperty SenderNameProperty = BindableProperty.Create(nameof(SenderUserName), typeof(string), typeof(Message), string.Empty);
        public Message(string text, User sender)
        {
            MessageText = text;
            _sender= sender;
        }

        public string MessageText 
        {
            get;
        }

        internal string SenderUserName { get => _sender.UserName; }

        public LayoutOptions ScreenPosition { get
            {
                if (SenderUserName == User.ThisUser)
                {
                    return LayoutOptions.End;
                }
                return LayoutOptions.Start;
            } 
        }

        private User _sender;

        
    }
}
