using wardrobe_wizard.Data;

namespace wardrobe_wizard;

public partial class App : Application
{
	// gets width of the screen in device's pixel measurements
	public static readonly double fullscreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;

	// database setup for individual items
    private static clothingItemRepository clothingItemRepo;
	public static clothingItemRepository ClothingItemRepo
	{
		get
		{
			// if there is a database already, don't make one. otherwise make one
			if (clothingItemRepo == null)
			{
                clothingItemRepo = new clothingItemRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clothingItems.db3"));
                Console.WriteLine("created clothing database at " + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)));
			}
			else
			{
				Console.WriteLine("clothing database already exists");
			}

			return clothingItemRepo;
		}
	}

    // database setup for outfits
    private static clothingItemRepository outfitRepo;
    public static clothingItemRepository OutfitRepo
    {
        get
        {
            // if there is a database already, don't make one. otherwise make one
            if (outfitRepo == null)
            {
                outfitRepo = new clothingItemRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "savedOutfits.db3"));
                Console.WriteLine("created outfit database at " + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "savedOutfits.db3"));
            }
            else
            {
                Console.WriteLine("outfit database already exists");
            }

            return outfitRepo;
        }
    }

    public App()
	{
		InitializeComponent();

        MainPage = new AppShell();
	}
}