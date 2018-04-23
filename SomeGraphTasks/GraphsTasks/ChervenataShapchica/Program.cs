using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChervenataShapchica
{
    class Program
    {
        private static int maxMoney;
        private static int currentMoney;
        private static HashSet<int> visitedDestinations = new HashSet<int>();
        private static Node[] destinations;
        private static int startNodeValue;

        static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());
            short[] moneyOnEachPlace = Console.ReadLine().Split().Select(Int16.Parse).ToArray();

            destinations = new Node[N];

            for (int i = 0; i < N; i++)
            {
                destinations[i] = new Node(i, moneyOnEachPlace[i]);
            }

            int[] currentPath;
            for (int i = 0; i < N - 1; i++)
            {
                currentPath = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
                destinations[currentPath[0] - 1].ConnectedDestinations.Add(destinations[currentPath[1] - 1]);
                destinations[currentPath[1] - 1].ConnectedDestinations.Add(destinations[currentPath[0] - 1]);
            }

            FindBestPath(N - 1);
            visitedDestinations.Clear();
            currentMoney = 0;
            maxMoney = 0;
            FindBestPath(startNodeValue);
            Console.WriteLine(maxMoney);
        }

        private static void FindBestPath(int destinationNumber)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(destinationNumber);
            visitedDestinations.Add(destinationNumber);

            while (stack.Count != 0)
            {
                Node currentNode = destinations[stack.Pop()];

                currentMoney += currentNode.Money;
                if (currentMoney > maxMoney)
                {
                    maxMoney = currentMoney;
                    startNodeValue = currentNode.Value;
                }

                for (int i = 0; i < currentNode.ConnectedDestinations.Count; i++)
                {
                    if (!visitedDestinations.Contains(currentNode.ConnectedDestinations[i].Value))
                    {
                        visitedDestinations.Add(currentNode.ConnectedDestinations[i].Value);
                        FindBestPath(currentNode.ConnectedDestinations[i].Value);
                    }
                }

                currentMoney -= currentNode.Money;
            }
        }
    }

    struct Node
    {
        private int value;
        private short money;
        private List<Node> connectedDestinations;

        public Node(int value, short money) : this()
        {
            this.Value = value;
            this.Money = money;
            this.connectedDestinations = new List<Node>();
        }

        public int Value { get => this.value; set => this.value = value; }
        public short Money { get => this.money; set => this.money = value; }
        public List<Node> ConnectedDestinations { get => this.connectedDestinations; set => this.connectedDestinations = value; }
    }
}