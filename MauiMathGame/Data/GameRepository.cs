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
            conn = new SQLiteConnection(_dbPath);  // Create instance of SQLite connection
            conn.CreateTable<Game>();  // Creates a table based on the specified Game model - model properties will become columns for the table
        }

        public List<Game> GetAllGames()
        {
            Init(); // Run Init method to create the table if it doesn't already exist
            return conn.Table<Game>().ToList(); // Retrieve games from table and convert it to a list
        }

        public void Add(Game game)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(game); // Insert game into the table
        }

        public void Delete(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete(new { Id = id }); // Delete record based on Id primary key
        }
    }
}
