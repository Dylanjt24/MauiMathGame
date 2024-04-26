using MauiMathGame.WinUI;

namespace MauiMathGame;

public partial class PreviousGames : ContentPage
{
    public PreviousGames()
    {
        InitializeComponent();
        gamesList.ItemsSource = App.GameRepository.GetAllGames(); // Get all played games and display them in the gamesList XAML visual component
    }

    private void OnDelete(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        App.GameRepository.Delete((int)button.BindingContext); // Grab Id button is bound to and pass it to the Delete method
        gamesList.ItemsSource = App.GameRepository.GetAllGames(); // Call GetAllGames to refresh games list after deletion
    }
}