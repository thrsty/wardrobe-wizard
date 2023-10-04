namespace wardrobe_wizard;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // changes width of each item so that it fills the screen
        NewFitBtn.WidthRequest = App.fullscreenWidth - 20;
        Border1.WidthRequest = App.fullscreenWidth - 20;
        Border2.WidthRequest = App.fullscreenWidth - 20;
        Border3.WidthRequest = App.fullscreenWidth - 20;
    }

    // directs user to new outfit page
    async private void OnNewFitClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//NewOutfit");
    }
}