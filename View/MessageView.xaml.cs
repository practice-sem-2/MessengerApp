using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Messenger_App.View;

public partial class MessageView : ContentView, INotifyPropertyChanged
{

	public string DisplayedText { get; set; }

	public string SenderDisplay { get; set; }

	public Image ProfilePicture { get; set; }

	public MessageView()
	{
		InitializeComponent();
	}
	public event PropertyChangedEventHandler PropertyChanged;
	public void OnPropertyChanged([CallerMemberName]string propertyName = null)
	{
		PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	
}