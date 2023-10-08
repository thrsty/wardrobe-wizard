using wardrobe_wizard.Models;

namespace wardrobe_wizard;

public partial class outfitView : ContentPage
{
    public outfitView()
    {
        InitializeComponent();
    }

    // refreshes page upon appearing
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        outfitCollectionView.ItemsSource = await App.OutfitRepo.GetItemsAsync();
    }

    // sends user to new navigation page
    void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//NewOutfit");
    }

    // when an item of clothing is selected, show the item's details page
    void outfitCollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        outfitComponents outfit = (outfitComponents)outfitCollectionView.SelectedItem;
        Navigation.PushAsync(new outfitDetails(outfit));
    }
}