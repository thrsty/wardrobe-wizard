using wardrobe_wizard.Models;
using wardrobe_wizard.Data;
using System.Reflection;

namespace wardrobe_wizard;

public partial class outfitDetails : ContentPage
{
    int delID;
    string imagePath;

    public outfitDetails(int id)
    {
        InitializeComponent();

        delID = id;
        imagePath = outfitRepository.GetOutfitAsync(id).Result.image;
        fitName.Text = outfitRepository.GetOutfitAsync(id).Result.name;

        // for each not null item of clothing in _outfitcomponents
        // add it to a list of type clothingItem objects and set that list
        // to the item source (took a lot of brainpower to make istg)
        outfitClothesView.ItemsSource = outfitItems(id);
    }

    // returns a list of all of the items in an outfit when given an outfit id
    List<clothingItem> outfitItems(int id)
    {
        List<clothingItem> outfitItems = new List<clothingItem>();
        outfitComponents outfitToDisplay;

        // gets the all of the parts of the outfit from the outfit database and sets it to temp outfit
        outfitToDisplay = outfitRepository.GetOutfitAsync(id).Result;
        Console.WriteLine(outfitToDisplay.name);

        // relfection voodoo magic gets ids for its clothingItems from outfitToDisplay properties
        // then gets the clothingItem properties as a clothingItem object from the clothingItem
        // database and adds it to a list of the parts of the outfit which is the itemSource for
        // the collectionView, which shows all of the items in the outfit.
        PropertyInfo[] properties = typeof(outfitComponents).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if (property.PropertyType == typeof(int) && property != null && property.Name.Equals("id") == false)
            {
                Console.WriteLine("property {0} = {1}", property.Name, property.GetValue(outfitToDisplay));
                int pk = Convert.ToInt32(property.GetValue(outfitToDisplay));
                Console.WriteLine("pk is " + pk);
                if (pk != 0)
                {
                    outfitItems.Add(clothingItemRepository.GetItemAsync(pk).Result);
                }
            }
        }

        // phew it's done
        return outfitItems;
    }

    // deletes the outfit (shocker)
    async void DeleteBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        // need to delete image file form system for clothing item
        File.Delete(imagePath);

        await outfitRepository.RemoveOutfitAsync(delID);
        await Navigation.PopAsync();
    }
}