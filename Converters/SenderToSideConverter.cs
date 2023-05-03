using Messenger_App.Model;
using System.Globalization;

namespace Messenger_App.Converters
{
    public class SenderToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            User user = (User)value;
            if (user.UserName != User.ThisUser)
                return LayoutOptions.Start;
            return LayoutOptions.End;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value as User).UserName != User.ThisUser)
                return LayoutOptions.Start;
            return LayoutOptions.End;
        }
    }
}
