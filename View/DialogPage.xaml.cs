using Messenger_App.ViewModel;

namespace Messenger_App.View;

public partial class DialogPage : ContentPage
{
	public DialogPage(DialogViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private void Back_Button_Clicked(object sender, EventArgs e)
    {
		Shell.Current.SendBackButtonPressed();
    }
}