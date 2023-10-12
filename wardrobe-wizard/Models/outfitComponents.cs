using SQLite;

namespace wardrobe_wizard.Models
{
    public class outfitComponents
    {
        // sqlite specific thing for unique ids
        [PrimaryKey, AutoIncrement]

        // display items of an outfit
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }

        // mandatory components
        public clothingItem shirt { get; set; }
        public clothingItem pants { get; set; }
        public clothingItem shoes { get; set; }

        // optional components
        public clothingItem jacket { get; set; }
        public clothingItem socks { get; set; }
        public clothingItem hat { get; set; }
        public clothingItem[] accessories { get; set; }
    }
}