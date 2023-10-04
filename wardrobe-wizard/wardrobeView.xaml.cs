using wardrobe_wizard.Models;

namespace wardrobe_wizard;

public partial class wardrobeView : ContentPage
{

	public wardrobeView()
	{
		InitializeComponent();
    }

    // refreshes page upon appearing
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        wardrobeCollectionView.ItemsSource = await App.ClothingItemRepo.GetItemsAsync();
    }

    // sends user to new navigation page
    void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new newItem());
    }

    // when an item of clothing is selected, show the item's details page
    void wardrobeCollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        clothingItem _clothingItem = (clothingItem)wardrobeCollectionView.SelectedItem;
        Navigation.PushAsync(new itemDetails(_clothingItem));
    }
}