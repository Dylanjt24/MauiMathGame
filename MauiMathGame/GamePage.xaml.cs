namespace MauiMathGame;

public partial class GamePage : ContentPage
{
    public string GameType { get; set; }
    int firstNumber = 0;
    int secondNumber = 0;
    public GamePage(string gameType)
    {
        InitializeComponent();
        GameType = gameType;
        // Need BindingContext in order to assign constructor gameType to the incoming GameType
        // "this" assigns the BindingContext to the current instance of this class
        BindingContext = this;

        CreateNewQuestion();
    }

    private void CreateNewQuestion()
    {
        // Switch statement defines which operation symbol is used based on the GameType
        // _ covers all options that weren't already covered; essentially acts like the "default"
        var gameOperand = GameType switch
        {
            "Addition" => "+",
            "Subtraction" => "-",
            "Multiplication" => "*",
            "Division" => "/",
            _ => ""
        };

        var random = new Random();
        // Ternary operator - (condition) ? expressionTrue : expressionFalse
        firstNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);
        secondNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);

        if (GameType == "Division")
        {
            while (firstNumber < secondNumber || firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }
        }

        // Replace QuestionLabel text with the math equation to solve
        QuestionLabel.Text = $"{firstNumber} {gameOperand} {secondNumber}";
    }
}