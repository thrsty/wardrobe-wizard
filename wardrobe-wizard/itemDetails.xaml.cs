using wardrobe_wizard.Models;

namespace wardrobe_wizard;

public partial class itemDetails : ContentPage
{
	public int id;

	public itemDetails(clothingItem _clothingItem)
	{
		InitializeComponent();

		id = _clothingItem.id;

		// sets each elements text to the specific item's values
		itemName.Text		= _clothingItem.name;
		itemColor.Text		= _clothingItem.color;
		itemType.Text		= _clothingItem.type;
		itemImage.Source	= _clothingItem.image;
		itemBrand.Text		= _clothingItem.brand;
		itemFit.Text		= _clothingItem.fit;
        itemMaterial.Text	= _clothingItem.material;
        itemPrice.Text		= _clothingItem.price;
		itemFormality.Text	= _clothingItem.formality;
		itemClean.Text		= _clothingItem.isClean.ToString();
    }

    async void deleteBtnClicked(System.Object sender, System.EventArgs e)
    {
		// if deletes item and goes back a page
		await App.ClothingItemRepo.RemoveItemAsync(id);
		await Navigation.PopAsync();
    }
}