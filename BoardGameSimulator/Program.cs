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

class Barbarian : Player
{
    public Barbarian(string name) { Name = name; }
}

class Mage : Player
{
    public Mage(string name) { Name = name; }
}

class Necromancer : Player
{
    public Necromancer(string name) { Name = name; }
}

class Game
    {
        private Board board;
        private List<IPlayer> players = new List<IPlayer>();
        private int currentPlayerIndex = 0;

        public event Action<IPlayer, int> OnPlayerReward;

        public Game(int boardSize)
        {
            board = new Board(boardSize);
        }

        public void AddPlayer(IPlayer player)
        {
            players.Add(player);
        }

        public void Start()
        {
            Console.WriteLine("Gra rozpoczęta!");
            board.DisplayBoard();
            while (true)
            {
                PlayTurn();
                Console.WriteLine("Kliknij 'enter' aby kontynuować, albo napisz 'koniec' aby zakończyć grę.");
                if (Console.ReadLine()?.ToLower() == "koniec") break;
            }

            DisplayResults();
        }
        private void PlayTurn()
        {
            var player = players[currentPlayerIndex];
            int steps = RollDice();
            player.Move(steps);

            int reward = board.CheckReward(player.Position);
            if (reward > 0)
            {
                player.UpdateScore(reward);
                OnPlayerReward?.Invoke(player, reward);
            }
            else
            {
                Console.WriteLine($"Brak nagrody dla {player.Name} na pozycji {player.Position}.");
            }

            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        }

        private int RollDice()
        {
            Random random = new Random();
            int roll = random.Next(1, 7);
            Console.WriteLine($"Rzut kością: {roll}");
            return roll;
        }
        
        private void DisplayResults()
        {
            Console.WriteLine("Gra zakończona! Wynik końcowy:");
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}: {player.Score} punktów");
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