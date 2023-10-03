namespace wardrobe_wizard;

public partial class photoPage : ContentPage
{
	public photoPage()
	{
		InitializeComponent();
	}

    void cameraView_CamerasLoaded(System.Object sender, System.EventArgs e)
    {
		cameraView.Camera = cameraView.Cameras.First();

		MainThread.BeginInvokeOnMainThread(async () =>
		{
			await cameraView.StopCameraAsync();
			var result = await cameraView.StartCameraAsync();
		});
    }
}