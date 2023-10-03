﻿using wardrobe_wizard.Models;
using wardrobe_wizard.Data;
using SQLite;

namespace wardrobe_wizard;

public partial class newItem : ContentPage
{
    public newItem()
    {
        InitializeComponent();

        // Adds different types of clothing to picker for user to pick from
        var typeList = new List<string>();
        typeList.Add("Top");
        typeList.Add("Bottom");
        typeList.Add("Jacket");
        typeList.Add("Shoes");
        typeList.Add("Socks");
        typeList.Add("Hat");
        typeList.Add("Ring/s");
        typeList.Add("Necklace");
        typePicker.ItemsSource = typeList;

        /* // Adds different fits of clothing to picker for user to pick from
        var fitList = new List<string>();
        fitList.Add("Tight");
        fitList.Add("Medium");
        fitList.Add("Baggy");
        fitPicker.ItemsSource = fitList;

        // Adds different prices of clothing to picker for user to pick from
        var priceList = new List<string>();
        priceList.Add("$");
        priceList.Add("$$");
        priceList.Add("$$$");
        pricePicker.ItemsSource = priceList;

        // Adds different formalities of clothing to picker for user to pick from
        var formalityList = new List<string>();
        formalityList.Add("Casual");
        formalityList.Add("Business Casual");
        formalityList.Add("Formal");
        formalityPicker.ItemsSource = formalityList; */
    }

    async void DoneBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Console.WriteLine("Add to database");


        // add item to database
        await App.ClothingItemRepo.SaveItemAsync(new clothingItem
        {
            name = nameOfItem.Text,
            type = typePicker.SelectedItem.ToString(),
            /* brand = brandOfItem.Text,
            fit = fitPicker.SelectedItem.ToString(),
            material = "clothing material",
            price = pricePicker.SelectedItem.ToString(),
            formality = formalityPicker.SelectedItem.ToString(),
            isClean = true */
        });
    }
}