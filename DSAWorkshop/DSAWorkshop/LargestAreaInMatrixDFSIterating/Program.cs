using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaInMatrixDFSIterating
{
    class Program
    {
        private static int[,] graph;
        private static bool[,] booleanGraph;
        private static Stack<Vertex> stack;
        private static int[] rowDirections = new int[] { 0, -1, 0, 1 };
        private static int[] colDirections = new int[] { -1, 0, 1, 0 };
        private static int bestCount = 0;
        private static int currentCount = 0;

        static void Main(string[] args)
        {
            int[] inputLine = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
            graph = new int[inputLine[0], inputLine[1]];
            booleanGraph = new bool[inputLine[0], inputLine[1]];

            for (int row = 0; row < graph.GetLength(0); row++)
            {
                inputLine = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
                for (int col = 0; col < graph.GetLength(1); col++)
                {
                    graph[row, col] = inputLine[col];
                }
            }

            stack = new Stack<Vertex>();

            for (int row = 0; row < graph.GetLength(0); row++)
            {
                for (int col = 0; col < graph.GetLength(1); col++)
                {
                    Vertex currentVertex = new Vertex(row, col);
                    IterativeDFS(currentVertex);
                    bestCount = Math.Max(bestCount, currentCount);
                    currentCount = 0;
                }
            }

            Console.WriteLine(bestCount);
        }

        private static void IterativeDFS(Vertex currentVertex)
        {
            stack.Push(currentVertex);
            while (stack.Count != 0)
            {
                currentVertex = stack.Pop();
                currentCount++;
                if ((!booleanGraph[currentVertex.Row, currentVertex.Col]))
                {
                    booleanGraph[currentVertex.Row, currentVertex.Col] = true;
                    foreach (Vertex vertex in GetAdjacentVertex(currentVertex))
                    {
                        stack.Push(vertex);
                    }
                }
            }
        }

        private static ICollection<Vertex> GetAdjacentVertex(Vertex currentVertex)
        {
            ICollection<Vertex> vertex = new List<Vertex>();
            Vertex currentCandidate;
            for (int i = 0; i < rowDirections.Length; i++)
            {
                currentCandidate = new Vertex(currentVertex.Row + rowDirections[i], currentVertex.Col + colDirections[i]);
                if ((currentCandidate.Row > -1 && currentCandidate.Row < graph.GetLength(0) && currentCandidate.Col > -1 && currentCandidate.Col < graph.GetLength(1)) && graph[currentCandidate.Row, currentCandidate.Col] == graph[currentVertex.Row, currentVertex.Col] && !booleanGraph[currentCandidate.Row, currentCandidate.Col])
                {
                    vertex.Add(currentCandidate);
                }
            }
            return vertex;
        }
    }

    class Vertex
    {
        public Vertex(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}