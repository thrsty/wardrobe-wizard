using wardrobe_wizard.Models;
using SQLite;

namespace wardrobe_wizard.Services
{
	public static class ClothesDatabase
	{
		static SQLiteAsyncConnection db;

		static async Task Init()
		{
			if (db != null)
				return;

			// Gets absolute path to the database file
			var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "clothesDatabase.db");
			db = new SQLiteAsyncConnection(databasePath);

			await db.CreateTableAsync<Clothes>();

			Console.WriteLine("Made the clothes database");
		}

		public static async Task AddItem(string name, string color, string type, string brand, string fit, string material, int price, string formality)
		{
			await Init();

			var image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/SVG_Logo.svg/1200px-SVG_Logo.svg.png";


            var item = new Clothes
			{
				name = name,
				image = image,
				color = color,
				type = type,
                brand = brand,
				fit = fit,
				material = material,
				price = price,
				formality = formality
			};

			var id = await db.InsertAsync(item);
		}

		public static async Task RemoveItem(int id)
		{
            await Init();

			await db.DeleteAsync<Clothes>(id);
        }

		public static async Task<IEnumerable<Clothes>> GetItem()
		{
            await Init();

			var item = await db.Table<Clothes>().ToListAsync();
			return item;
        }
	}
}