using MauiMathGame.WinUI;

namespace MauiMathGame;

public partial class PreviousGames : ContentPage
{
    public PreviousGames()
    {
        InitializeComponent();
        gamesList.ItemsSource = App.GameRepository.GetAllGames(); // Get all played games and display them in the gamesList XAML visual component
    }
}