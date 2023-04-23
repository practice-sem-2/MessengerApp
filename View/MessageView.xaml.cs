namespace Messenger_App.View;

public partial class MessageView : ContentView
{
	public static readonly BindableProperty SenderDisplayProperty = BindableProperty.Create(nameof(SenderDisplay), typeof(string), typeof(MessageView), string.Empty);
	public static readonly BindableProperty MessageDisplayProperty = BindableProperty.Create(nameof(DisplayedText), typeof(string), typeof(MessageView), string.Empty);

    public string DisplayedText { get => (string)GetValue(MessageDisplayProperty); set => SetValue(MessageDisplayProperty, value); }

	public string SenderDisplay { get => (string)GetValue(SenderDisplayProperty); set => SetValue(SenderDisplayProperty, value); }
		
	public Image ProfilePicture { get; set; }

	public MessageView()
	{
		InitializeComponent();
	}
	
}