using wardrobe_wizard.Models;
using wardrobe_wizard.Data;

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
        outfitCollectionView.ItemsSource = await outfitRepository.GetOutfitsAsync();
    }

    // sends user to new outfit page, incase they don't see the one at the bottom of the screen for some reason...
    void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//NewOutfit");
    }

    // when an outfit is selected, show the outfit's details page
    void outfitCollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        Navigation.PushAsync(new outfitDetails(((outfitComponents)outfitCollectionView.SelectedItem).id));
    }
}