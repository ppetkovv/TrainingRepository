using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    class Program
    {
        private static BigList<Player> playersCollection = new BigList<Player>();
        private static Dictionary<string, OrderedSet<Player>> orderedPlayersByType = new Dictionary<string, OrderedSet<Player>>();
        private static StringBuilder finalResult = new StringBuilder();

        public static void Main()
        {
            string[] splittedCommand;
            string command = Console.ReadLine();
            for (; command != "end";)
            {
                splittedCommand = command.Split();

                switch (splittedCommand[0])
                {
                    case "add":
                        AddPlayerCommand(splittedCommand);
                        break;
                    case "find":
                        FindPlayersByTypeCommand(splittedCommand);
                        break;
                    case "ranklist":
                        GetRanklist(splittedCommand);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.Write(finalResult);
        }

        private static void GetRanklist(string[] splittedCommand)
        {
            int start = Int32.Parse(splittedCommand[1]);
            int end = Int32.Parse(splittedCommand[2]);

            List<Player> ranklist = playersCollection.Range(start - 1, end - start + 1).ToList();

            StringBuilder tempResult = new StringBuilder();
            for (int i = 0; i < ranklist.Count; i++)
            {
                tempResult.Append(string.Format("{0}. {1}; ", start + i, ranklist[i]));
            }
            finalResult.AppendLine(tempResult.ToString().TrimEnd(new char[] { ';', ' ' }));
        }

        private static void FindPlayersByTypeCommand(string[] splittedCommand)
        {
            string playerType = splittedCommand[1];

            if (!orderedPlayersByType.ContainsKey(playerType))
            {
                finalResult.AppendLine(string.Format("Type {0}: ", playerType));
            }
            else
            {
                finalResult.AppendLine(string.Format("Type {0}: ", playerType) + string.Join("; ", orderedPlayersByType[playerType]));
            }
        }

        private static void AddPlayerCommand(string[] splittedCommand)
        {
            int positionForAdding = Int32.Parse(splittedCommand[4]);
            string playerForAddingType = splittedCommand[2];
            Player playerForAdding = new Player(splittedCommand[1], playerForAddingType, Int32.Parse(splittedCommand[3]));
            playersCollection.Insert(positionForAdding - 1, playerForAdding);
            if (orderedPlayersByType.ContainsKey(playerForAddingType))
            {
                if (orderedPlayersByType[playerForAddingType].Count < 5)
                {
                    orderedPlayersByType[playerForAddingType].Add(playerForAdding);
                }
                else
                {
                    if (orderedPlayersByType[playerForAddingType].GetLast().CompareTo(playerForAdding) > 0)
                    {
                        orderedPlayersByType[playerForAddingType].Add(playerForAdding);
                        orderedPlayersByType[playerForAddingType].RemoveLast();
                    }
                }
            }
            else
            {
                orderedPlayersByType.Add(playerForAddingType, new OrderedSet<Player>());
                orderedPlayersByType[playerForAddingType].Add(playerForAdding);
            }
            finalResult.AppendLine(string.Format("Added player {0} to position {1}", splittedCommand[1], positionForAdding));
        }
    }

    struct Player : IComparable<Player>
    {
        private string name;
        private string type;
        private int age;

        public Player(string name, string type, int age):this()
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
        }

        public string Name { get => this.name; set => this.name = value; }
        public string Type { get => this.type; set => this.type = value; }
        public int Age { get => this.age; set => this.age = value; }

        public int CompareTo(Player other)
        {
            int resultForReturning = this.name.CompareTo(other.name);
            if (resultForReturning == 0)
            {
                resultForReturning = other.age.CompareTo(this.age);
            }
            return resultForReturning;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.name, this.age);
        }
    }
}