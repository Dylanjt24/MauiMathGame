using SQLite;

namespace MauiMathGame.Data
{
    public class GameRepository
    {
        string _dbPath; // Where database lives in file system
        private SQLiteConnection conn;

        public GameRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void Init()
        {

        }
    }
}
