using SQLite;
using wardrobe_wizard.Models;

namespace wardrobe_wizard.Data
{
    public class outfitRepository
    {
        public static SQLiteAsyncConnection outfitDb;

        public outfitRepository()
        {
        }

        // initialise the database
        async static Task init()
        {
            if (outfitDb != null)
                return;

            outfitDb = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "savedOutfits.db3"));
            await outfitDb.CreateTableAsync<outfitComponents>();
            Console.WriteLine("made outfit database");
        }

        // returns all outfitComponents in the database
        async static public Task<List<outfitComponents>> GetOutfitsAsync()
        {
            await init();
            Console.WriteLine("getting outfits");
            return await outfitDb.Table<outfitComponents>().ToListAsync();
        }

        // adds row to database with clothingItem fields
        async static public Task<int> SaveOutfitAsync(outfitComponents _outfitComponents)
        {
            await init();
            Console.WriteLine("saving outfit");
            return await outfitDb.InsertAsync(_outfitComponents);
        }

        // deletes entry from clothes database
        public static async Task<int> RemoveOutfitAsync(int id)
        {
            await init();
            Console.WriteLine("deleting outfit");
            return await outfitDb.DeleteAsync<outfitComponents>(id);
        }
    }
}