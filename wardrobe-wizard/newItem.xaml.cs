using wardrobe_wizard.Models;
using wardrobe_wizard.Data;

namespace wardrobe_wizard;

public partial class newItem : ContentPage
{
    public newItem()
    {
        InitializeComponent();

        // Adds different colours of clothing to picker for user to pick from
        var colorList = new List<string>()
        {
            "Black", "White", "Red", "Pink", "Orange", "Yellow", "Green", "Blue", "Violet", "Cream"
        };
        colorPicker.ItemsSource = colorList;

        // Adds different types of clothing to picker for user to pick from
        var typeList = new List<string>()
        {
            "T-shirt", "Long sleeved t-shirt", "Pants", "Shorts", "Jacket", "Shoes", "Socks", "Hat", "Ring/s", "Necklace"
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
            "$", "$$", "$$$", "$$$$"
        };
        pricePicker.ItemsSource = priceList;

        // Adds different formalities of clothing to picker for user to pick from
        var formalityList = new List<string>()
        {
            "Casual", "Business casual", "Formal"
        };
        formalityPicker.ItemsSource = formalityList;
    }

    // push new page to take photo of said outfit that will save to db
    void photoNavBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        // validation
        if (string.IsNullOrEmpty(nameOfItem.Text) == true || string.IsNullOrEmpty(brandOfItem.Text) == true || string.IsNullOrEmpty(materialOfItem.Text) == true)
        {
            Console.WriteLine("You need to fill in all of the fields");
            return;
        }

        // this be making the new page
        Navigation.PushAsync( new clothingPhotoPage(new clothingItem
        {
            name = nameOfItem.Text,
            color = colorPicker.SelectedItem.ToString(),
            type = typePicker.SelectedItem.ToString(),
            brand = brandOfItem.Text,
            fit = fitPicker.SelectedItem.ToString(),
            material = materialOfItem.Text,
            price = pricePicker.SelectedItem.ToString(),
            formality = formalityPicker.SelectedItem.ToString(),
            isClean = true
        }));
    }
}