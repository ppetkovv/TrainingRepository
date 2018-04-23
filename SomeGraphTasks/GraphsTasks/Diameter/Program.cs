//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Diameter
//{
//    class Program
//    {
//        private static int bestPath = 0;
//        private static int currentPath = 0;
//        private static Node[] graph;
//        private static HashSet<int> visitedNodesIndexes = new HashSet<int>();
//        private static HashSet<int> edgesValuesToStart = new HashSet<int>();

//        static void Main(string[] args)
//        {
//            int N = Int32.Parse(Console.ReadLine());
//            graph = new Node[N];

//            int[] currentInputLine;
//            int firstNodeValue = 0;
//            int secondNodeValue = 0;
//            int edgeConnection = 0;

//            for (int i = 1; i < N; i++)
//            {
//                currentInputLine = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
//                firstNodeValue = currentInputLine[0];
//                secondNodeValue = currentInputLine[1];
//                edgeConnection = currentInputLine[2];

//                if (graph[firstNodeValue] == null)
//                {
//                    graph[firstNodeValue] = new Node(firstNodeValue);
//                }

//                if (graph[secondNodeValue] == null)
//                {
//                    graph[secondNodeValue] = new Node(secondNodeValue);
//                }

//                graph[firstNodeValue].Children.Add(graph[secondNodeValue]);
//                graph[firstNodeValue].EdgeConnections.Add(edgeConnection);
//                graph[secondNodeValue].Children.Add(graph[firstNodeValue]);
//                graph[secondNodeValue].EdgeConnections.Add(edgeConnection);
//            }

//            edgesValuesToStart.Add(0);
//            for (int i = 0; i < edgesValuesToStart.Count; i++)
//            {
//                DFS(i);
//                visitedNodesIndexes.Clear();
//            }
//            Console.WriteLine(bestPath);
//        }

//        private static void DFS(int currentNodeIndex)
//        {
//            Stack<int> stack = new Stack<int>();
//            stack.Push(currentNodeIndex);
//            visitedNodesIndexes.Add(currentNodeIndex);

//            while (stack.Count != 0)
//            {
//                int nodeIndex = stack.Pop();
//                Node currentNode = graph[nodeIndex];
//                List<Node> currentNodeChildren = currentNode.Children;
//                List<int> currentNodeEdgeConnections = currentNode.EdgeConnections;

//                for (int i = 0; i < currentNodeChildren.Count; i++)
//                {
//                    if(currentNodeChildren.Count == 1)
//                    {
//                        edgesValuesToStart.Add(currentNodeIndex);
//                    }
//                    if (!visitedNodesIndexes.Contains(currentNodeChildren[i].Value))
//                    {
//                        currentPath += currentNodeEdgeConnections[i];
//                        bestPath = Math.Max(currentPath, bestPath);
//                        DFS(currentNodeChildren[i].Value);
//                        currentPath -= currentNodeEdgeConnections[i];
//                    }
//                }
//            }
//        }
//    }

//    class Node
//    {
//        private int value;
//        private List<Node> children;
//        private List<int> edgeConnections;

//        public Node(int value)
//        {
//            this.Value = value;
//            this.children = new List<Node>();
//            this.edgeConnections = new List<int>();
//        }

//        public int Value { get => this.value; set => this.value = value; }
//        public List<Node> Children { get => this.children; set => this.children = value; }
//        public List<int> EdgeConnections { get => this.edgeConnections; set => this.edgeConnections = value; }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diameter
{
    class Program
    {
        private static int bestPath = 0;
        private static int currentPath = 0;
        private static Node[] graph;
        private static HashSet<int> visitedNodesIndexes = new HashSet<int>();
        private static int nodeIndexToStart = 0;

        static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());
            graph = new Node[N];

            int[] currentInputLine;
            int firstNodeValue = 0;
            int secondNodeValue = 0;
            int edgeConnection = 0;

            for (int i = 1; i < N; i++)
            {
                currentInputLine = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
                firstNodeValue = currentInputLine[0];
                secondNodeValue = currentInputLine[1];
                edgeConnection = currentInputLine[2];

                if (graph[firstNodeValue] == null)
                {
                    graph[firstNodeValue] = new Node(firstNodeValue);
                }

                if (graph[secondNodeValue] == null)
                {
                    graph[secondNodeValue] = new Node(secondNodeValue);
                }

                graph[firstNodeValue].Children.Add(graph[secondNodeValue]);
                graph[firstNodeValue].EdgeConnections.Add(edgeConnection);
                graph[secondNodeValue].Children.Add(graph[firstNodeValue]);
                graph[secondNodeValue].EdgeConnections.Add(edgeConnection);
            }

            DFS(3);

            currentPath = 0;
            bestPath = 0;
            visitedNodesIndexes.Clear();

            DFS(nodeIndexToStart);
            Console.WriteLine(bestPath);
        }

        private static void DFS(int currentNodeIndex)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(currentNodeIndex);
            visitedNodesIndexes.Add(currentNodeIndex);

            while (stack.Count != 0)
            {
                int nodeIndex = stack.Pop();
                Node currentNode = graph[nodeIndex];
                List<Node> currentNodeChildren = currentNode.Children;
                List<int> currentNodeEdgeConnections = currentNode.EdgeConnections;

                for (int i = 0; i < currentNodeChildren.Count; i++)
                {
                    if (!visitedNodesIndexes.Contains(currentNodeChildren[i].Value))
                    {
                        currentPath += currentNodeEdgeConnections[i];
                        if (currentPath > bestPath)
                        {
                            bestPath = currentPath;
                            nodeIndexToStart = currentNodeChildren[i].Value;
                        }
                        DFS(currentNodeChildren[i].Value);
                        currentPath -= currentNodeEdgeConnections[i];
                    }
                }
            }
        }
    }

    class Node
    {
        private int value;
        private List<Node> children;
        private List<int> edgeConnections;

        public Node(int value)
        {
            this.Value = value;
            this.children = new List<Node>();
            this.edgeConnections = new List<int>();
        }

        public int Value { get => this.value; set => this.value = value; }
        public List<Node> Children { get => this.children; set => this.children = value; }
        public List<int> EdgeConnections { get => this.edgeConnections; set => this.edgeConnections = value; }
    }
}