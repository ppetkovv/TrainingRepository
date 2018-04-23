using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friends
{
    class Program
    {
        private static int connectionsBetweenTwoCitiesCount;
        private static int startCity;
        private static int endCity;
        private static int firstIntermediateCity;
        private static int secondIntermediateCity;
        private static List<Node>[] graph;
        private static int currentDistance = 0;
        private static int finalDistance = Int32.MaxValue;
        private static int[] distance;

        static void Main(string[] args)
        {
            string currentInput = Console.ReadLine();
            string wholeInput = currentInput+"\n";
            int[] input = currentInput.Split().Select(Int32.Parse).ToArray();
            graph = new List<Node>[input[0]];
            connectionsBetweenTwoCitiesCount = input[1];

            currentInput = Console.ReadLine();
            wholeInput += currentInput+"\n";
            input = currentInput.Split().Select(Int32.Parse).ToArray();
            startCity = input[0] - 1;
            endCity = input[1] - 1;

            currentInput = Console.ReadLine();
            wholeInput += currentInput + "\n";
            input = currentInput.Split().Select(Int32.Parse).ToArray();
            firstIntermediateCity = input[0] - 1;
            secondIntermediateCity = input[1] - 1;

            for (int i = 0; i < connectionsBetweenTwoCitiesCount; i++)
            {
                currentInput = Console.ReadLine();
                wholeInput += currentInput + "\n";
                input = currentInput.Split().Select(Int32.Parse).ToArray();
                int firstCity = input[0] - 1;
                int secondCity = input[1] - 1;

                if (graph[firstCity] == null)
                {
                    graph[firstCity] = new List<Node>();
                }
                if (graph[secondCity] == null)
                {
                    graph[secondCity] = new List<Node>();
                }

                graph[firstCity].Add(new Node() { Vertex = secondCity, Weight = input[2] });
                graph[secondCity].Add(new Node() { Vertex = firstCity, Weight = input[2] });
            }


            Dijkstra(startCity, secondIntermediateCity, endCity, firstIntermediateCity);

            Dijkstra(firstIntermediateCity, startCity, endCity, secondIntermediateCity);

            Dijkstra(secondIntermediateCity, startCity, firstIntermediateCity, endCity);

            finalDistance = Math.Min(currentDistance, finalDistance);
            currentDistance = 0;

            Dijkstra(startCity, firstIntermediateCity, endCity, secondIntermediateCity);

            Dijkstra(secondIntermediateCity, startCity, endCity, firstIntermediateCity);

            Dijkstra(firstIntermediateCity, startCity, secondIntermediateCity, endCity);

            finalDistance = Math.Min(currentDistance, finalDistance);

            Console.WriteLine(finalDistance);
        }

        private static void Dijkstra(int startCity, int firstForbiddenCity, int secondForbiddenCity, int searchedCityShortestValue)
        {
            SortedSet<Node> priorityQueue = new SortedSet<Node>();
            HashSet<int> visited = new HashSet<int>();
            priorityQueue.Add(new Node() { Vertex = startCity });
            distance = Enumerable.Repeat(Int32.MaxValue, graph.Length).ToArray();
            distance[startCity] = 0;

            while (priorityQueue.Count > 0)
            {
                Node currentNode = priorityQueue.Min();
                visited.Add(currentNode.Vertex);
                priorityQueue.Remove(currentNode);

                foreach (Node childNode in graph[currentNode.Vertex].Where(curNode => curNode.Vertex != firstForbiddenCity && curNode.Vertex != secondForbiddenCity))
                {
                    int currentDistance = distance[childNode.Vertex];
                    int newDistance = distance[currentNode.Vertex] + childNode.Weight;

                    if (newDistance < currentDistance)
                    {
                        distance[childNode.Vertex] = newDistance;
                        priorityQueue.Add(childNode);
                    }
                }

                while (priorityQueue.Count > 0 && visited.Contains(priorityQueue.Min().Vertex))
                {
                    priorityQueue.Remove(priorityQueue.Min());
                }
            }
            currentDistance += distance[searchedCityShortestValue];
        }
    }

    class Node : IComparable<Node>
    {
        public int Vertex { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Node other)
        {
            int resultForReturning = this.Weight.CompareTo(other.Weight);
            if (resultForReturning == 0)
            {
                resultForReturning = this.Vertex.CompareTo(other.Vertex);
            }
            return resultForReturning;
        }
    }
}