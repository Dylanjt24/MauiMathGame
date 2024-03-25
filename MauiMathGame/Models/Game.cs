using Windows.Gaming.XboxLive.Storage;

namespace MauiMathGame.Models
{
    public class Game
    {
        public int Id { get; set; }
        public GameSaveOperationResult Type { get; set; }
        public int Score { get; set; }
        public DateTime DatePlayed { get; set; }
    }

    public enum GameOperation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }
}