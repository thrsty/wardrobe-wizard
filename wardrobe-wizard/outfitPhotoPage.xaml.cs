using wardrobe_wizard.Models;
using wardrobe_wizard.Data;

namespace wardrobe_wizard;

public partial class outfitPhotoPage : ContentPage
{
    public string imagePath;
    public outfitComponents outfitToAdd;

    public outfitPhotoPage(outfitComponents _outfitComponents)
    {
        InitializeComponent();
        outfitToAdd = _outfitComponents;
    }

    // sets camera to first camera on device when cameras are accessed
    // idk what linq does tbh
    void cameraView_CamerasLoaded(System.Object sender, System.EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.First();

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StopCameraAsync();
            await cameraView.StartCameraAsync();
        });
    }

    // takes photo
    void takePhoto_Clicked(System.Object sender, System.EventArgs e)
    {
        // gets image path string
        imagePath = App.getImagePath("outfit");

        // saves current image on camera display
        cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
        cameraView.SaveSnapShot(Camera.MAUI.ImageFormat.PNG, imagePath);

        // stops camera and resets camera-related ui elements
        cameraView.StopCameraAsync();
    }

    // click this when youve added everything
    async void DoneBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        // validation
        if (string.IsNullOrEmpty(imagePath))
        {
            Console.WriteLine("you need to take a photo of the outfit");
            return;
        }

        // add item to database and goes back to wardrobe view
        await outfitRepository.SaveOutfitAsync(new outfitComponents
        {
            name = outfitToAdd.name,
            image = imagePath,

            // mandatory components
            shirt = outfitToAdd.shirt,
            pants = outfitToAdd.pants,
            shoes = outfitToAdd.shoes,

            // optional components
            jacket = outfitToAdd.jacket,
            socks = outfitToAdd.socks,
            hat = outfitToAdd.hat
        });

        await Navigation.PopAsync();
        await Shell.Current.GoToAsync("//outfitView");
    }
}