using wardrobe_wizard.Data;

namespace wardrobe_wizard;

public partial class App : Application
{
	// gets width of the screen in devices pixel measurements
	public static readonly double fullscreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;

	// database setup
    private static clothingItemRepository clothingItemRepo;
	public static clothingItemRepository ClothingItemRepo
	{
		get
		{
			if (clothingItemRepo == null)
			{
                clothingItemRepo = new clothingItemRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clothingItems.db3"));
                Console.WriteLine("created database at " + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)));
			}
			else
			{
				Console.WriteLine("database already exists");
			}

			return clothingItemRepo;
		}
	}

	public App()
	{
		InitializeComponent();

        MainPage = new AppShell();
	}
}