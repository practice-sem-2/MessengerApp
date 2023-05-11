
using Messenger_App.View;

namespace Messenger_App.Model
{
    public class Message
    {
        public static readonly BindableProperty MessageTextProperty = BindableProperty.Create(nameof(MessageText), typeof(string), typeof(Message), string.Empty);
        public static readonly BindableProperty SenderNameProperty = BindableProperty.Create(nameof(SenderName), typeof(string), typeof(Message), string.Empty);
        
        public Message(string text, User sender)
        {
            MessageText = text;
            _sender = sender;
            _senderUserName = sender.UserName; //this is a late pre-deadline decision, to display system messages
        }

        public string MessageText 
        {
            get;
            set;
        }

        private string _senderUserName;
        internal string SenderName { get => _senderUserName; set => _senderUserName = value; }

        public LayoutOptions ScreenPosition { get
            {
                if (SenderName == User.ThisUserName)
                    return LayoutOptions.End;
                if(SenderName == "System")
                    return LayoutOptions.Center;
                return LayoutOptions.Start;
            } 
        }

        private User _sender;

        public Color MessageColor
        {
            get
            {
                if(SenderName == User.ThisUserName)
                {
                    return Color.FromRgb(144, 231, 252);
                }
                if(SenderName == "System")
                {
                    return Color.FromRgb(251, 252, 182);
                }
                return Color.FromRgb(170, 153, 255);
            }
        }
            


    }
}
