using wardrobe_wizard.Data;

namespace wardrobe_wizard;

public partial class App : Application
{
    // gets width of the screen in device's pixel measurements
    public static readonly double fullscreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;

    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();

        startClothingDB();
    }

    // starts the clothing database because the async lazy load doesn't work with the
    // sync getItem task but task doesn't work if it's async so it's sync
    async void startClothingDB()
    {
        await clothingItemRepository.init();
    }

    // used for unique names of clothing photos
    public static string getImagePath(string type)
    {
        int count = 0;

        // iterates image filename by one if a file with the same name exists
        while (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), type + count.ToString() + ".png")) == true)
        {
            count++;
        }

        // double check on implementation
        Console.WriteLine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), type + count.ToString() + ".png"));

        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), type + count.ToString() + ".png");
    }
}