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

class Board
{
    public int Size { get; private set; }
    private Dictionary<int, int> rewards = new Dictionary<int, int>();

    public Board(int size)
    {
        Size = size;
        GenerateRewards();
    }

    private void GenerateRewards()
    {
        Random random = new Random();
        for (int i = 1; i <= Size / 2; i++)
        {
            int position = random.Next(1, Size + 1);
            int points = random.Next(1, 11);
            rewards[position] = points;
        }
    }

    public int CheckReward(int position)
    {
        return rewards.ContainsKey(position) ? rewards[position] : 0;
    }

    public void DisplayBoard()
    {
        Console.WriteLine("Nagrody na planszy:");
        foreach (var reward in rewards)
        {
            Console.WriteLine($"Pozycja {reward.Key}: {reward.Value} punktów");
        }
    }
}
internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}