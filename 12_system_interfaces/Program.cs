using System.Collections;
using System.Collections.Generic;

namespace _12_system_interfaces
{
    class Player : IComparable<Player>, ICloneable
    {
        public string Nickname { get; set; }
        public int BestScore { get; set; }
        public int Games { get; set; }

        public object Clone()
        {
            // make a shallow copy - copy value types only
            var copy = (Player)this.MemberwiseClone();

            // make a deep copy - copy reference types also
            copy.Nickname = (string)this.Nickname.Clone();
            //...

            return copy;
        }

        public int CompareTo(Player? other)
        {
            // Compare result:
            // 0    - elemets are equals
            // < 0  - first elememt less than second
            // > 0  - first elememt bigger than second
            return this.Nickname.CompareTo(other.Nickname);
        }

        public override string ToString()
        {
            return $"Player {Nickname} - best score: {BestScore} points!";
        }
    }

    class Team : IEnumerable
    {
        public List<Player> Players { get; set; }
        public string[] Achivements { get; } = { "I", "II", "III", "VII" };

        public Team()
        {
            Players = new List<Player>()
            {
                new Player()
                {
                    Nickname = "super44",
                    BestScore = 350,
                    Games = 22
                },
                new Player()
                {
                    Nickname = "bob_bob",
                    BestScore = 560,
                    Games = 55
                },
                new Player()
                {
                    Nickname = "micky77",
                    BestScore = 845,
                    Games = 23
                },
                new Player()
                {
                    Nickname = "fisher",
                    BestScore = 120,
                    Games = 30
                },
                new Player()
                {
                    Nickname = "blabla",
                    BestScore = 430,
                    Games = 26
                }
            };
        }

        public void AddPlayer(Player newPlayer)
        {
            Players.Add(newPlayer);
        }
        public void DeleteAllPlayers()
        {
            Players.Clear();
        }
        public void SortByScore()
        {
            this.Players.Sort();
        }

        public IEnumerator GetEnumerator()
        {
            return this.Players.GetEnumerator();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = new[] { 4, 6, 1, 0, 123, 0, -4 };
            //List<int> numbers = new List<int>() { 4, 6, 1, 0, 123, 0, -4 };

            //numbers.Add(777);

            //foreach (var n in numbers)
            //{
            //    Console.WriteLine(n);
            //}

            Team team = new Team();

            team.SortByScore();

            foreach (var item in team)
            {
                //Console.WriteLine(item);
            }

            Player player = new Player()
            {
                Nickname = "vlad",
                BestScore = 555,
                Games = 33
            };

            // create a copy of the player
            Player copy = (Player)player.Clone();

            player.BestScore = 0;

            Console.WriteLine("Original:\t" + player);
            Console.WriteLine("Copy:\t\t" + copy);
        }
    }
}