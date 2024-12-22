using System;
using System.Collections.Generic;

interface IPlayer
{
    string Name { get; set; }
    int Position { get; set; }
    int Score { get; set; }
    void Move(int steps);
    void UpdateScore(int points);
}

class Player : IPlayer
{
    public string Name { get; set; }
    public int Position { get; set; } = 0;
    public int Score { get; set; } = 0;

    public void Move(int steps)
    {
        Position += steps;
        Console.WriteLine($"{Name} przemieszcza się na pozycję {Position}.");
    }

    public void UpdateScore(int points)
    {
        Score += points;
        Console.WriteLine($"{Name} zyskuje {points} punktów. Obecny wynik: {Score}");
    }
}
internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}