﻿using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace MauiMathGame.Models
{
    [Table("game")]  // Table attribute not necessary since the class is already named "Game", just for example purposes
    public class Game
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public GameOperation Type { get; set; }
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