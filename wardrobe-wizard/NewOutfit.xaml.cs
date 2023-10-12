using wardrobe_wizard.Models;
using wardrobe_wizard.Data;

namespace wardrobe_wizard;

public partial class NewOutfit : ContentPage
{
    List<clothingItem> itemIds = new List<clothingItem>();

    public NewOutfit()
    {
        InitializeComponent();
    }

    // refreshes page upon appearing
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        itemsCollectionView.ItemsSource = await clothingItemRepository.GetItemsAsync();
    }

    // when an item of clothing is selected, show the item's details page
    void itemsCollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            clothingItem _clothingItem = e.CurrentSelection[e.CurrentSelection.Count - 1] as clothingItem;
            itemIds.Add(_clothingItem);

            foreach (clothingItem __clothingItem in itemIds)
            {
                Console.WriteLine("id is " + __clothingItem.id);
            }
            Console.WriteLine(itemIds.Count);
        }
    }

    void doneBtnClicked(System.Object sender, System.EventArgs e)
    {
        Console.WriteLine("done button clicked");
        new outfitComponents
        {
            shirt = itemIds[0]
        };
    }
}