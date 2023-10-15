using SQLite;
using wardrobe_wizard.Models;

namespace wardrobe_wizard.Data
{
    public class outfitRepository
    {
        public static SQLiteAsyncConnection outfitDb;
        static string dbPathOutfit = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "savedOutfits.db3");

        public outfitRepository()
        {
        }

        // initialise the outfit database
        async static public Task init()
        {
            if (outfitDb != null)
                return;

            outfitDb = new SQLiteAsyncConnection(dbPathOutfit);
            await outfitDb.CreateTableAsync<outfitComponents>();
            Console.WriteLine("made outfit database at " + dbPathOutfit);
        }

        // returns all outfitComponents in the database
        async static public Task<List<outfitComponents>> GetOutfitsAsync()
        {
            await init();
            Console.WriteLine("getting outfits at " + dbPathOutfit);
            return await outfitDb.Table<outfitComponents>().ToListAsync();
        }

        // returns specific outfit
        public static Task<outfitComponents> GetOutfitAsync(int id)
        {
            Task.Run(init);
            Task.WaitAll();
            Console.WriteLine("getting outfit component from " + outfitDb.DatabasePath);
            return outfitDb.GetAsync<outfitComponents>(id);
        }

        // adds row to database with outfitComponent fields
        async static public Task<int> SaveOutfitAsync(outfitComponents _outfitComponents)
        {
            await init();
            Console.WriteLine("saving outfit to " + dbPathOutfit);
            return await outfitDb.InsertAsync(_outfitComponents);
        }

        // deletes entry from outfit database
        async static public Task<int> RemoveOutfitAsync(int id)
        {
            await init();
            Console.WriteLine("deleting outfit from " + dbPathOutfit);
            return await outfitDb.DeleteAsync<outfitComponents>(id);
        }
    }
}