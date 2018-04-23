using System;
using System.Collections.Generic;
using System.Linq;

namespace Beers
{
    class Program
    {
        private static Node[] graph;
        private static int[] distance;

        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
            int matrixRows = input[0];
            int matrixCols = input[1];
            int beers = input[2];

            graph = new Node[beers + 2];
            graph[0] = new Node() { Index = 0, IsBeer = false, Position = new Position(0, 0) };
            graph[graph.Length - 1] = new Node() { Index = graph.Length - 1, IsBeer = false, Position = new Position(matrixRows - 1, matrixCols - 1) };

            for (int i = 0; i < beers; i++)
            {
                input = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
                graph[i + 1] = new Node() { Index = i + 1, IsBeer = true, Position = new Position(input[0], input[1]) };
            }

            Dijkstra(0);
            Console.WriteLine(distance[graph.Length - 1]);
        }

        private static void Dijkstra(int startIndex)
        {
            SortedSet<Node> priorityQueue = new SortedSet<Node>();
            priorityQueue.Add(graph[startIndex]);
            HashSet<int> visited = new HashSet<int>();
            distance = Enumerable.Repeat(Int32.MaxValue, graph.Length).ToArray();
            distance[startIndex] = 0;

            while (priorityQueue.Count > 0)
            {
                Node currentNode = priorityQueue.Min();
                visited.Add(currentNode.Index);
                priorityQueue.Remove(currentNode);

                foreach (Node neighbour in graph.Where(currNode => currNode.Position.Row != currentNode.Position.Row || currNode.Position.Col != currentNode.Position.Col))
                {
                    int mainNodeRow = currentNode.Position.Row;
                    int mainNodeCol = currentNode.Position.Col;
                    int neighbourNodeRow = neighbour.Position.Row;
                    int neighbourNodeCol = neighbour.Position.Col;

                    int distanceToNeighbour = Math.Max(mainNodeRow, neighbourNodeRow) - Math.Min(mainNodeRow, neighbourNodeRow) + Math.Max(mainNodeCol, neighbourNodeCol) - Math.Min(mainNodeCol, neighbourNodeCol);
                    int currentDistance = distance[neighbour.Index];
                    int newDistance = distance[currentNode.Index] + distanceToNeighbour;
                    if (neighbour.IsBeer)
                    {
                        newDistance -= 5;
                    }

                    if (newDistance < currentDistance)
                    {
                        distance[neighbour.Index] = newDistance;
                        priorityQueue.Add(neighbour);
                    }
                }

                while (priorityQueue.Count > 0 && visited.Contains(priorityQueue.Min.Index))
                {
                    priorityQueue.Remove(priorityQueue.Min);
                }
            }
        }
    }

    class Node : IComparable<Node>
    {
        public int Index { get; set; }
        public Position Position { get; set; }
        public bool IsBeer { get; set; }

        public int CompareTo(Node other)
        {
            int resultForReturning = (Position.Row + Position.Col).CompareTo(other.Position.Row + other.Position.Col);
            if (resultForReturning == 0)
            {
                resultForReturning = this.Index.CompareTo(other.Index);
            }
            return resultForReturning;
        }
    }

    struct Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}