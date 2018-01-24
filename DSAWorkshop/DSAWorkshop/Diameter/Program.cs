using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diameter
{
    class Program
    {
        private static List<WeightedNode>[] graph;

        static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());
            graph = new List<WeightedNode>[N];

            int[] currentLineValues;
            int parentNodeValue;
            int childNodeValue;
            int connectionLength;

            for (int i = 0; i < N - 1; i++)
            {
                currentLineValues = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
                parentNodeValue = currentLineValues[0];
                childNodeValue = currentLineValues[1];
                connectionLength = currentLineValues[2];

                if (graph[parentNodeValue] == null)
                {
                    graph[parentNodeValue] = new List<WeightedNode>();
                }

                if (graph[childNodeValue] == null)
                {
                    graph[childNodeValue] = new List<WeightedNode>();
                }

                graph[parentNodeValue].Add(new WeightedNode(childNodeValue, connectionLength));
                graph[childNodeValue].Add(new WeightedNode(parentNodeValue, connectionLength));
            }

            Dijkstra(3);

        }

        private static void Dijkstra(int startNodeValue)
        {
            HashSet<int> visited = new HashSet<int>();
            SortedSet<WeightedNode> queue = new SortedSet<WeightedNode>();
            int[] d = Enumerable.Repeat(Int32.MinValue, graph.Length).ToArray();

            d[startNodeValue] = 0;
            queue.Add(new WeightedNode(startNodeValue, 0));

            while (queue.Count > 0)
            {
                var current = queue.Max;
                queue.Remove(current);
                visited.Add(current.Value);

                //Calculate distances!!!
                for (int i = 0; i < graph[current.Value].Count; i++)
                {
                    int currentD = d[graph[current.Value][i].Value];
                    int newD = d[current.Value] + graph[current.Value][i].Weight;
                    if (currentD < newD)
                    {
                        d[graph[current.Value][i].Value] = newD;
                        queue.Add(new WeightedNode(graph[current.Value][i].Value, newD));
                    }
                }

                while (queue.Count > 0 && visited.Contains(queue.Max.Value))
                {
                    queue.Remove(queue.Max);
                }
            }
        }
    }

    class WeightedNode : IComparable<WeightedNode>
    {
        public WeightedNode(int value, int weight)
        {
            this.Value = value;
            this.Weight = weight;
        }

        public int Value { get; set; }
        public int Weight { get; set; }

        public int CompareTo(WeightedNode other)
        {
            int returnedValue = this.Weight.CompareTo(other.Weight);
            if (returnedValue == 0)
            {
                returnedValue = this.Value.CompareTo(other.Value);
            }
            return returnedValue;
        }
    }
}