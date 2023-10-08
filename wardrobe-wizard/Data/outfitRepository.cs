using SQLite;
using wardrobe_wizard.Models;

namespace wardrobe_wizard.Data
{
	public class outfitRepository
	{
        private readonly SQLiteAsyncConnection _database;

		// initialise the database
        public outfitRepository(string dbPath)
		{
			_database = new SQLiteAsyncConnection(dbPath);
			_database.CreateTableAsync<outfitComponents>();
            Console.WriteLine("made sqliteAsyncConnection to outfit database");
        }

		// returns all clothingItems in the database
		public Task<List<outfitComponents>> GetItemsAsync()
		{
			Console.WriteLine("getting outfits");
            return _database.Table<outfitComponents>().ToListAsync();
		}

		// adds row to database with clothingItem fields
		public Task<int> SaveItemAsync(outfitComponents _outfitComponents)
		{
			Console.WriteLine("saving outfit");
			return _database.InsertAsync(_outfitComponents);
		}

		// deletes entry from clothes database
		public Task RemoveItemAsync(int id)
		{
			return _database.DeleteAsync<outfitComponents>(id);
		}
	}
}