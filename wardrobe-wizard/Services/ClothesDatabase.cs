using System;
using wardrobe_wizard.Models;
using SQLite;

namespace wardrobe_wizard.Services
{
	public class ClothesDatabase
	{
		static SQLiteAsyncConnection db;

		static async Task Init()
		{
			if (db != null)
				return;

			// Gets absolute path to the database file
			var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ClothesDatabase.db");
			db = new SQLiteAsyncConnection(databasePath);
		}
	}
}

