using wardrobe_wizard.Models;
using wardrobe_wizard.Data;

namespace wardrobe_wizard;

public partial class itemDetails : ContentPage
{
    int id;
    string imagePath;

    public itemDetails(clothingItem _clothingItem)
    {
        InitializeComponent();

        id = _clothingItem.id;

        itemImage.Source = _clothingItem.image;
        imagePath = _clothingItem.image;


        // makes a list of all of the properties so that they can be used in a collectionView rather than
        // making a bunch of individual items
        List<clothingItemProperty> itemProperties = new List<clothingItemProperty>
        {
            new clothingItemProperty("Name", _clothingItem.name),
            new clothingItemProperty("Color", _clothingItem.color),
            new clothingItemProperty("Type", _clothingItem.type),
            new clothingItemProperty("Brand", _clothingItem.brand),
            new clothingItemProperty("Fit", _clothingItem.fit),
            new clothingItemProperty("Material", _clothingItem.material),
            new clothingItemProperty("Price", _clothingItem.price),
            new clothingItemProperty("Formality", _clothingItem.formality),
            new clothingItemProperty("Clean", _clothingItem.isClean.ToString())
        };

        itemDetailsView.ItemsSource = itemProperties;
    }

    async void deleteBtnClicked(System.Object sender, System.EventArgs e)
    {
        // need to delete image file form system for clothing item
        File.Delete(imagePath);

        // deletes item and goes back a page
        await clothingItemRepository.RemoveItemAsync(id);
        await Navigation.PopAsync();
    }
}