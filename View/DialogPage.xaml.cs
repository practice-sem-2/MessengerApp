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

    private void ContentPage_Appearing(object sender, EventArgs e)
    {

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        (BindingContext as DialogViewModel).SendMessage.Execute(SenderEntry.Text);
        SenderEntry.Text = "";
        //x:Reference crashed app on PROD, so i cant use Commands properly
    }
}