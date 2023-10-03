using wardrobe_wizard.Models;
using wardrobe_wizard.Data;
using System.Collections.ObjectModel;

namespace wardrobe_wizard;

public partial class wardrobeView : ContentPage
{

	public wardrobeView()
	{
		InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //wardrobeCollectionView.ItemsSource = await App.ClothingItemRepo.GetItemsAsync();
    }

    void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new newItem());
    }

    async void ToolbarItem_Clicked_1(System.Object sender, System.EventArgs e)
    {
        wardrobeCollectionView.ItemsSource = await App.ClothingItemRepo.GetItemsAsync();
    }
}