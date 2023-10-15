using wardrobe_wizard.Data;
using wardrobe_wizard.Models;

namespace wardrobe_wizard;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // changes width of each item so that it fills the screen
        NewFitBtn.WidthRequest = App.fullscreenWidth - 20;

        // Determines what the greeting is depending on time of day
        if (DateTime.Now.Hour < 12 && DateTime.Now.Hour >= 0)
        {
            greetingLabel.Text = "Good morning!";
        }
        else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 18)
        {
            greetingLabel.Text = "Good afternoon!";
        }
        else
        {
            greetingLabel.Text = "Good evening!";
        }

        divider.WidthRequest = App.fullscreenWidth;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        itemsView.ItemsSource = await clothingItemRepository.GetItemsAsync();
        outfitView.ItemsSource = await outfitRepository.GetOutfitsAsync();
    }

    // directs user to new outfit page
    async private void OnNewFitClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//NewOutfit");
    }

    void itemsView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        Navigation.PushAsync(new itemDetails((clothingItem)itemsView.SelectedItem));
    }

    void outfitView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        Navigation.PushAsync(new outfitDetails(((outfitComponents)outfitView.SelectedItem).id));
    }
}