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
        public int shirt { get; set; }
        public int pants { get; set; }
        public int shoes { get; set; }

        // optional components
        public int jacket { get; set; }
        public int socks { get; set; }
        public int hat { get; set; }
    }
}