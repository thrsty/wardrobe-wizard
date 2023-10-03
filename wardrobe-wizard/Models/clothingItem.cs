using System;
using SQLite;

namespace wardrobe_wizard.Models
{
	public class clothingItem
	{
		[PrimaryKey, AutoIncrement]

        public int id { get; set; }
		public string name { get; set; }
        //public string color { get; set; }
        public string type { get; set; }
        /*public string image { get; set; }
        public string brand { get; set; }
        public string fit { get; set; }
        public string material { get; set; }
        public string price { get; set; }
        public string formality { get; set; }
        public bool isClean { get; set; } */
    }
}