using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathInGraphBFS
{
    class Program
    {
        static void Main(string[] args)
        {
            //            string input = @"3 1
            //5 4
            //3 4
            //5 3
            //1 2
            //5 2
            //3 6";
            //            string[] splittedInput = input.Split(new char[] { '\n' });

            int n = Int32.Parse(Console.ReadLine());
            int m = Int32.Parse(Console.ReadLine());

            List<Node>[] graph = new List<Node>[n];
            int[] path = new int[n];
            path[0] = -1;

            for (int i = 0; i < m; i++)
            {
                int[] currentRelation = Console.ReadLine().Split().Select(Int32.Parse).ToArray();

                if (graph[currentRelation[0] - 1] == null)
                {
                    graph[currentRelation[0] - 1] = new List<Node>();
                }

                if (graph[currentRelation[1] - 1] == null)
                {
                    graph[currentRelation[1] - 1] = new List<Node>();
                }

                graph[currentRelation[0] - 1].Add(new Node(currentRelation[1] - 1));
                graph[currentRelation[1] - 1].Add(new Node(currentRelation[0] - 1));
            }

            BFS(graph, 0, path);

            int currentIndex = path.Length - 1;

            while (currentIndex != -1)
            {
                Console.WriteLine(currentIndex + 1);
                currentIndex = path[currentIndex];
            }
        }

        private static void BFS(List<Node>[] graph, int startIndex, int[] path)
        {
            Queue<Node> queue = new Queue<Node>();
            HashSet<int> visitedNodesValues = new HashSet<int>();
            Node startNode = new Node(0);
            queue.Enqueue(startNode);
            visitedNodesValues.Add(0);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Dequeue();
                for (int i = 0; i < graph[currentNode.Value].Count; i++)
                {
                    Node currentChild = graph[currentNode.Value][i];
                    if (!visitedNodesValues.Contains(currentChild.Value))
                    {
                        currentChild.Previous = currentNode;
                        queue.Enqueue(currentChild);
                        visitedNodesValues.Add(currentChild.Value);
                        path[currentChild.Value] = currentNode.Value;
                    }
                }
            }
        }
    }

    class Node
    {
        private int value;
        private Node previous;

        public Node(int value)
        {
            this.Value = value;
        }

        public Node(int value, Node previous) : this(value)
        {
            this.Previous = previous;
        }

        public int Value { get => this.value; set => this.value = value; }
        public Node Previous { get => this.previous; set => this.previous = value; }
    }
}