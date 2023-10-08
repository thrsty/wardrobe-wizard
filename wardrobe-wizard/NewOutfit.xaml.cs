namespace wardrobe_wizard;
public partial class NewOutfit : ContentPage
{
    public NewOutfit()
    {
        InitializeComponent();
        double fullscreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density - 40;
        outfitPlus.MaximumWidthRequest = fullscreenWidth;
        outfitPlus.MaximumHeightRequest = fullscreenWidth;

        genOutfitButton.MaximumWidthRequest = fullscreenWidth;
        genOutfitButton.MaximumHeightRequest = fullscreenWidth;

        occasionButton.MaximumWidthRequest = fullscreenWidth;
        occasionButton.MaximumHeightRequest = fullscreenWidth;

        tagsEnterButton.MaximumWidthRequest = fullscreenWidth;
        tagsEnterButton.MaximumHeightRequest = fullscreenWidth;
    }
}