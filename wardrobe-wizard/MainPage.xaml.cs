namespace wardrobe_wizard;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        NewFitBtn.WidthRequest = App.fullscreenWidth - 20;
        Border1.WidthRequest = App.fullscreenWidth - 20;
        Border2.WidthRequest = App.fullscreenWidth - 20;
        Border3.WidthRequest = App.fullscreenWidth - 20;
    }

    async private void OnNewFitClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//NewOutfit");
    }
}