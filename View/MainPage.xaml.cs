using Messenger_App.Model;
using Messenger_App.ViewModel;
using System.Globalization;

namespace Messenger_App.View;

public partial class MainPage : ContentPage
{
    
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new DialogViewModel();
	}
}

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