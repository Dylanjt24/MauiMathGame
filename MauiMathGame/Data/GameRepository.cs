using MauiMathGame.Models;
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
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Game>();  // Creates a table based on the specified Game model - model properties will become columns for the table
        }

        public List<Game> GetAllGames()
        {
            Init(); // Run Init method to create the table if it doesn't already exist
            return conn.Table<Game>().ToList(); // Retrieve games from table and convert it to a list
        }
    }
}
