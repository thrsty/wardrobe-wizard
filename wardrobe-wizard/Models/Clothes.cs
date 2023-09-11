using System;
using SQLite;

namespace wardrobe_wizard.Models
{
	public class Clothes
	{
		[PrimaryKey, AutoIncrement]

		public string name { get; set; }
        public int id { get; set; }
        public string color { get; set; }
        public string type { get; set; }
        public Image Image { get; set; }
        public string brand { get; set; }
        public string fit { get; set; }
        public string material { get; set; }
        public int price { get; set; }
        public string formality { get; set; }
        public bool isClean { get; set; }
    }
}

