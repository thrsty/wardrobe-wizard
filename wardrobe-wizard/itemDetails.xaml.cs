using wardrobe_wizard.Models;

namespace wardrobe_wizard;

public partial class itemDetails : ContentPage
{
	public int id;

	public itemDetails(clothingItem _clothingItem)
	{
		InitializeComponent();

		id = _clothingItem.id;

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

    void deleteBtnClicked(System.Object sender, System.EventArgs e)
    {
		App.ClothingItemRepo.RemoveItemAsync(id);

		deleteBtn.Text = "will delete";
    }
}