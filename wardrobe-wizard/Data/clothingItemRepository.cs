using SQLite;
using wardrobe_wizard.Models;

namespace wardrobe_wizard.Data
{
	public class clothingItemRepository
	{
        private readonly SQLiteAsyncConnection _database;

		// initialise the database
        public clothingItemRepository(string dbPath)
		{
			_database = new SQLiteAsyncConnection(dbPath);
			_database.CreateTableAsync<clothingItem>();
            Console.WriteLine("made sqliteAsyncConnection");
        }

		// returns all clothingItems in the database
		public Task<List<clothingItem>> GetItemsAsync()
		{
			Console.WriteLine("getting items");
            return _database.Table<clothingItem>().ToListAsync();
		}

		// adds row to database with clothingItem fields
		public Task<int> SaveItemAsync(clothingItem _clothingItem)
		{
			Console.WriteLine("saving item");
			return _database.InsertAsync(_clothingItem);
		}

		// deletes entry from clothes database
		public Task RemoveItemAsync(int id)
		{
			return _database.DeleteAsync<clothingItem>(id);
		}
	}
}