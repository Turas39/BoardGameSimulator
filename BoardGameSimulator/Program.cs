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
internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}