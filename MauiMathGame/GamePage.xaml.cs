using MauiMathGame.Models;

namespace MauiMathGame;

public partial class GamePage : ContentPage
{
    public string GameType { get; set; }
    int firstNumber = 0;
    int secondNumber = 0;
    int score = 0;
    const int totalQuestions = 2;
    int gamesLeft = totalQuestions;
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
        //var gameOperand = GameType switch
        //{
        //    "Addition" => "+",
        //    "Subtraction" => "-",
        //    "Multiplication" => "*",
        //    "Division" => "/",
        //    _ => ""
        //};

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
        QuestionLabel.Text = $"{firstNumber} {GameType} {secondNumber}";
    }

    private void OnAnswerSubmitted(object sender, EventArgs e)
    {
        // Cast user's answer into an int
        var answer = Int32.Parse(AnswerEntry.Text);
        var isCorrect = false;

        // Checks whether or not the answer was correct based on the GameType being played
        switch (GameType)
        {
            case "+":
                isCorrect = answer == firstNumber + secondNumber;
                break;
            case "-":
                isCorrect = answer == firstNumber - secondNumber;
                break;
            case "�":
                isCorrect = answer == firstNumber * secondNumber;
                break;
            case "�":
                isCorrect = answer == firstNumber / secondNumber;
                break;
        }

        // Call ProcessAnswer with the result from the above switch statement
        ProcessAnswer(isCorrect);
        // Reduce num of games left after question is answered
        gamesLeft--;
        // Make sure the AnswerEntry is emptied when question is finished
        AnswerEntry.Text = "";

        if (gamesLeft > 0)
            CreateNewQuestion();
        else
            GameOver();
    }

    private void GameOver()
    {
        // Utilizes GameOperation enum in Game.cs to set game operation based on button clicked
        GameOperation gameOperation = GameType switch
        {
            "+" => GameOperation.Addition,
            "-" => GameOperation.Subtraction,
            "�" => GameOperation.Multiplication,
            "�" => GameOperation.Division
        };

        // Make question area invisible when game ends, and make back to menu button visible
        QuestionArea.IsVisible = false;
        BackToMenuBtn.IsVisible = true;
        GameOverLabel.Text = $"Game over! You got {score} out of {totalQuestions} correct.";

        // Add game to the GameRepository to keep track of games played
        App.GameRepository.Add(new Game
        {
            Type = gameOperation,
            Score = score,
            DatePlayed = DateTime.Now
        });
    }

    private void ProcessAnswer(bool isCorrect)
    {
        // Increase score if answer is correct
        if (isCorrect)
            score++;

        // Ternary to replace AnswerLabel text with whether or not the answer was correct
        AnswerLabel.Text = isCorrect ? "Correct!" : "Incorrect";
    }

    private void OnBackToMenu(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}