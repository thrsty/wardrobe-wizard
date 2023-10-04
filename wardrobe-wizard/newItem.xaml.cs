using Camera.MAUI;
using wardrobe_wizard.Models;

namespace wardrobe_wizard;

public partial class newItem : ContentPage
{
    public string imagePath;
    double fitPicFileName = 0;

    public newItem()
    {
        InitializeComponent();

        // Adds different types of clothing to picker for user to pick from
        var typeList = new List<string>()
        {
            "Top", "Bottom", "Jacket", "Shoes", "Socks", "Hat", "Ring/s", "Necklace"
        };
        typePicker.ItemsSource = typeList;

        // Adds different fits of clothing to picker for user to pick from
        var fitList = new List<string>()
        {
            "Tight", "Medium", "Baggy"
        };
        fitPicker.ItemsSource = fitList;

        // Adds different prices of clothing to picker for user to pick from
        var priceList = new List<string>()
        {
            "$", "$$", "$$$"
        };
        pricePicker.ItemsSource = priceList;

        // Adds different formalities of clothing to picker for user to pick from
        var formalityList = new List<string>()
        {
            "Casual", "Business casual", "Formal"
        };
        formalityPicker.ItemsSource = formalityList;
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

    // increases camera view size and the take photo button size, worlds worst animation
    void openCameraBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        cameraView.WidthRequest = 400;
        cameraView.HeightRequest = 400;

        takePhoto.MaximumHeightRequest = openCameraBtn.Height;
        takePhoto.MaximumWidthRequest = openCameraBtn.Width;
    }

    void takePhoto_Clicked(System.Object sender, System.EventArgs e)
    {
        // gets the name for the file
        fitPicFileName = getHighestPhotoNumberID();

        // combines directory with fitPicFileName string and sets the clothingItem's itemPath attribute to this path
        imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fitPicFileName.ToString() + ".png");

        // saves current image on camera display
        cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
        cameraView.SaveSnapShot(Camera.MAUI.ImageFormat.PNG, imagePath);

        // double check?
        Console.WriteLine(imagePath);

        // stops camera and resets camera-related ui elements
        cameraView.StopCameraAsync();

        cameraView.WidthRequest = 0;
        cameraView.HeightRequest = 0;

        takePhoto.MaximumHeightRequest = 0;
        takePhoto.MaximumWidthRequest = 0;
    }

    async void DoneBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        // add item to database and goes back to wardrobe view
        await App.ClothingItemRepo.SaveItemAsync(new clothingItem
        {
            name = nameOfItem.Text,
            // need to implement colour picker
            color = "000000",
            type = typePicker.SelectedItem.ToString(),
            image = imagePath,
            brand = brandOfItem.Text,
            fit = fitPicker.SelectedItem.ToString(),
            material = materialOfItem.Text,
            price = pricePicker.SelectedItem.ToString(),
            formality = formalityPicker.SelectedItem.ToString(),
            isClean = true
        });

        await Navigation.PopAsync();
    }

    int getHighestPhotoNumberID()
    {
        int count = 0;

        // iterates image filename by one if a file with the same name exists
        while (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), count.ToString() + ".png")) == true)
        {
            count++;
        }

        return count;
    }
}