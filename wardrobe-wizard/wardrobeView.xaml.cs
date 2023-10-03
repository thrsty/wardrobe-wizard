using wardrobe_wizard.Models;

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
        wardrobeCollectionView.ItemsSource = await App.ClothingItemRepo.GetItemsAsync();
    }

    void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new newItem());
    }

    async void ToolbarItem_Clicked_1(System.Object sender, System.EventArgs e)
    {
        wardrobeCollectionView.ItemsSource = await App.ClothingItemRepo.GetItemsAsync();
    }

    void wardrobeCollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        clothingItem _clothingItem = (clothingItem)wardrobeCollectionView.SelectedItem;
        Navigation.PushAsync(new itemDetails(_clothingItem));
    }
}