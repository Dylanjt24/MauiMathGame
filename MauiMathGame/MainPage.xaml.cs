namespace MauiMathGame;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    //sender object has information about the object, EventArgs is a .NET class that has information about the event
    private void OnGameChosen(object sender, EventArgs e)
    {
        // Cast anonymous sender object to Button type
        Button button = (Button)sender;

        Navigation.PushAsync(new GamePage(button.Text));
    }

    private void OnViewPreviousGamesChosen(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PreviousGames());
    }
}
