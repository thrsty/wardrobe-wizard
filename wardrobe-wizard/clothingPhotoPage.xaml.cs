using wardrobe_wizard.Models;
using wardrobe_wizard.Data;

namespace wardrobe_wizard;

public partial class clothingPhotoPage : ContentPage
{
    public string imagePath;
    public clothingItem itemToAdd;

    public clothingPhotoPage(clothingItem _clothingItem)
    {
        InitializeComponent();

        itemToAdd = _clothingItem;
    }

    // sets camera to first camera on device when cameras are accessed
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
        // get the filepath for the image
        imagePath = App.getImagePath("item");

        // saves current image on camera display
        cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
        cameraView.SaveSnapShot(Camera.MAUI.ImageFormat.PNG, imagePath);

        // double check?
        Console.WriteLine(imagePath);

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
        await clothingItemRepository.SaveItemAsync(new clothingItem
        {
            name = itemToAdd.name,
            color = itemToAdd.color,
            type = itemToAdd.type,
            image = imagePath,
            brand = itemToAdd.brand,
            fit = itemToAdd.fit,
            material = itemToAdd.material,
            price = itemToAdd.price,
            formality = itemToAdd.formality,
            isClean = true
        });

        await Shell.Current.GoToAsync("//wardrobeView");
    }
}
