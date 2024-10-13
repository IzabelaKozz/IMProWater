using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace IMProWater.Data
{
    public class Database
    {
        private static SQLiteAsyncConnection _database;

        public static SQLiteAsyncConnection DatabaseInstance
        {
            get
            {
                if (_database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "IMProWater.db3");
                    _database = new SQLiteAsyncConnection(dbPath);
                    _database.CreateTableAsync<User>().Wait();
                }
                return _database;
            }
        }
    }

    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
