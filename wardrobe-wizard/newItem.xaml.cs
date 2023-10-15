using wardrobe_wizard.Models;
using wardrobe_wizard.Data;

namespace wardrobe_wizard;

public partial class newItem : ContentPage
{
    public newItem()
    {
        InitializeComponent();

        // Adds elements to each picker to pick from
        colorPicker.ItemsSource = new List<string> { "Black", "White", "Red", "Pink", "Orange", "Yellow", "Green", "Blue", "Violet", "Cream" };
        typePicker.ItemsSource = new List<string> { "T-shirt", "Long sleeved t-shirt", "Pants", "Shorts", "Jacket", "Shoes", "Socks", "Hat", "Ring/s", "Necklace" };
        fitPicker.ItemsSource = new List<string> { "Tight", "Medium", "Baggy" };
        pricePicker.ItemsSource = new List<string> { "$", "$$", "$$$", "$$$$" };
        formalityPicker.ItemsSource = new List<string> { "Casual", "Business casual", "Formal" };
    }

    // push new page to take photo of said outfit that will save to db
    void photoNavBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        // validation
        if (string.IsNullOrWhiteSpace(nameOfItem.Text) == true ||
            string.IsNullOrWhiteSpace(colorPicker.SelectedItem.ToString()) == true ||
            string.IsNullOrWhiteSpace(typePicker.SelectedItem.ToString()) == true ||
            string.IsNullOrWhiteSpace(brandOfItem.Text) == true ||
            string.IsNullOrWhiteSpace(fitPicker.SelectedItem.ToString()) == true ||
            string.IsNullOrWhiteSpace(materialOfItem.Text) == true ||
            string.IsNullOrWhiteSpace(pricePicker.SelectedItem.ToString()) == true ||
            string.IsNullOrWhiteSpace(formalityPicker.SelectedItem.ToString()) == true)
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