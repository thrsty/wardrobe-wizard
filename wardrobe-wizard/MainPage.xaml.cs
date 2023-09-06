namespace wardrobe_wizard;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		double fullscreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density - 40;
		NewFitBtn.WidthRequest = fullscreenWidth;
		Border1.WidthRequest = fullscreenWidth;
        Border2.WidthRequest = fullscreenWidth;
        Border3.WidthRequest = fullscreenWidth;
    }

	async private void OnNewFitClicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("//NewOutfit");
    }
}