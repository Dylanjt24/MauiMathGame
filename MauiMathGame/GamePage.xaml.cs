namespace MauiMathGame;

public partial class GamePage : ContentPage
{
    public string GameType { get; set; }
    public GamePage(string gameType)
    {
        InitializeComponent();
        GameType = gameType;
        // Need BindingContext in order to assign constructor gameType to the incoming GameType
        // "this" assigns the BindingContext to the current instance of this class
        BindingContext = this;
    }
}