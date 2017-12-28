using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancingMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(Int32.Parse).ToArray();

            int counter;
            string direction;
            int step;
            long currentSum = 0;
            int currentIndex = 0;
            List<long> playerPoints = new List<long>();
            string[] splittedCommand;
            string command = Console.ReadLine();
            while (!command.Equals("stop"))
            {
                splittedCommand = command.Split();
                counter = Int32.Parse(splittedCommand[0]);
                direction = splittedCommand[1];
                step = Int32.Parse(splittedCommand[2]);
                currentSum = 0;

                for (int i = 0; i < counter && direction == "right"; i++)
                {
                    currentIndex += step;
                    while (currentIndex >= inputNumbers.Length)
                    {
                        currentIndex -= inputNumbers.Length;
                    }
                    currentSum += inputNumbers[currentIndex];
                }
                for (int i = 0; i < counter && direction == "left"; i++)
                {
                    currentIndex -= step;
                    while (currentIndex < 0)
                    {
                        currentIndex = inputNumbers.Length + currentIndex;
                    }
                    currentSum += inputNumbers[currentIndex];
                }

                playerPoints.Add(currentSum);

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Format("{0:F1}", (decimal)playerPoints.Sum() / playerPoints.Count));
        }
    }
}
