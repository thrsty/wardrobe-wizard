namespace wardrobe_wizard;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

        NewFitBtn.WidthRequest = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density - 20;
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private void OnNewFitClicked(object sender, EventArgs e)
	{
        NewFitBtn.WidthRequest = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density - 20;
		Console.WriteLine(DeviceDisplay.MainDisplayInfo.Width);
		Console.WriteLine(DeviceDisplay.MainDisplayInfo.Density);
    }
}