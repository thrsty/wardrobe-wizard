using System;
using System.Collections.Generic;
using SQLite;
using System.IO;
using wardrobe_wizard.Models;

namespace wardrobe_wizard.Data
{
	public class clothingItemRepository
	{
        private readonly SQLiteAsyncConnection _database;

		// init
        public clothingItemRepository(string dbPath)
		{
			_database = new SQLiteAsyncConnection(dbPath);
			_database.CreateTableAsync<clothingItem>();
            Console.WriteLine("made sqliteAsyncConnection");
        }

		// returns all database items
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