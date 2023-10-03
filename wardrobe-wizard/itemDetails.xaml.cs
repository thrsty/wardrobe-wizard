using wardrobe_wizard.Models;
using wardrobe_wizard.Data;

namespace wardrobe_wizard;

public partial class itemDetails : ContentPage
{
	public int id;

	public itemDetails(clothingItem _clothingItem)
	{
		InitializeComponent();

		id = _clothingItem.id;
	}

    void deleteBtnClicked(System.Object sender, System.EventArgs e)
    {
		App.ClothingItemRepo.RemoveItemAsync(id);

		deleteBtn.Text = "will delete";
    }
}