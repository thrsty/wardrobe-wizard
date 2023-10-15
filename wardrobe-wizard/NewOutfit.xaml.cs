using wardrobe_wizard.Models;
using wardrobe_wizard.Data;

namespace wardrobe_wizard;

public partial class NewOutfit : ContentPage
{
    int shirtID, pantsID, shoesID, jacketID, socksID, hatID;
    List<clothingItem> items = new List<clothingItem>();

    public NewOutfit()
    {
        InitializeComponent();
    }

    // refreshes page upon appearing
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // selectedItems thing is munted because it doesn't change when you go from another page back to it
        // so this sets it to null when the page appears so that only newly selected items are added
        itemsCollectionView.SelectedItems = null;

        itemsCollectionView.ItemsSource = await clothingItemRepository.GetItemsAsync();
    }

    // adds all of the clothingItems that are selected to items list to be used in doneBtnClicked method
    void itemsCollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        items = new List<clothingItem>();
        foreach (clothingItem item in itemsCollectionView.SelectedItems)
        {
            items.Add(item);
        }
    }

    // pushes photo page where the outfit is finalised
    void photoNav_Clicked(System.Object sender, System.EventArgs e)
    {
        // validation
        int shirtSum = 0, pantsSum = 0, shoesSum = 0, jacketSum = 0, socksSum = 0, hatSum = 0;

        foreach (clothingItem item in items)
        {
            // sorry
            if (item.type.Equals("T-shirt") || item.type.Equals("Long sleeved t-shirt"))
            {
                shirtSum++;
                shirtID = item.id;
            }
            else if (item.type.Equals("Pants") || item.type.Equals("Shorts"))
            {
                pantsSum++;
                pantsID = item.id;
            }
            else if (item.type.Equals("Shoes"))
            {
                shoesSum++;
                shoesID = item.id;
            }
            else if (item.type.Equals("Jacket"))
            {
                jacketSum++;
                jacketID = item.id;
            }
            else if (item.type.Equals("Socks"))
            {
                socksSum++;
                socksID = item.id;
            }
            else if (item.type.Equals("Hat"))
            {
                hatSum++;
                hatID = item.id;
            }
        }

        // you can never be too careful
        Console.WriteLine(shirtSum + " " + pantsSum + " " + shoesSum + " " + jacketSum + " " + socksSum + " " + hatSum);

        // if outfit does not have one shirt, pair of pants, pair of shoes or any other conditions here it will not add it the database.
        if (shirtSum != 1 || pantsSum != 1 || shoesSum != 1 || jacketSum > 1 || socksSum > 1 || hatSum > 1 || nameOfFit.Text == null || nameOfFit.Text == string.Empty)
        {
            Console.WriteLine("You cannot select more than one type of clothing per outfit.");
            Console.WriteLine("You also need a shirt, pair of pants, and pair of shoes per outfit");
            Console.WriteLine("You also need a name and image");
            return;
        }

        string fitName = nameOfFit.Text;
        nameOfFit.Text = null;

        // push outfit photo page with current outfit properties
        Navigation.PushAsync(new outfitPhotoPage (new outfitComponents
        {
            name = fitName,
            shirt = shirtID,
            pants = pantsID,
            shoes = shoesID,
            jacket = jacketID,
            socks = socksID,
            hat = hatID,
        }));
    }
}