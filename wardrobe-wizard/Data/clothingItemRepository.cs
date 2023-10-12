using SQLite;
using wardrobe_wizard.Models;

namespace wardrobe_wizard.Data
{
    public class clothingItemRepository
    {
        public static SQLiteAsyncConnection clothingDb;

        public clothingItemRepository()
        {
        }

        // initialise the clothing database
        public async static Task init()
        {
            if (clothingDb is not null)
                return;

            clothingDb = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clothingItems.db3"));
            await clothingDb.CreateTableAsync<clothingItem>();
            Console.WriteLine("made clothing database at " + clothingDb.DatabasePath);
        }

        // returns all clothingItems in the database
        async static public Task<List<clothingItem>> GetItemsAsync()
        {
            await init();
            Console.WriteLine("getting items");
            return await clothingDb.Table<clothingItem>().ToListAsync();
        }

        // returns specific outfit
        static public Task<clothingItem> GetItemAsync(int id)
        {
            Task.Run(init);
            Task.WaitAll();
            Console.WriteLine("getting clothingItem from " + clothingDb.DatabasePath);
            return clothingDb.GetAsync<clothingItem>(id);
        }

        // adds row to database with clothingItem fields
        async static public Task<int> SaveItemAsync(clothingItem _clothingItem)
        {
            await init();
            Console.WriteLine("saving item");
            return await clothingDb.InsertAsync(_clothingItem);
        }

        // deletes entry from clothes database
        async static public Task<int> RemoveItemAsync(int id)
        {
            await init();
            Console.WriteLine("deleting item");
            return await clothingDb.DeleteAsync<clothingItem>(id);
        }
    }
}