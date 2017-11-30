using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaInMatrix
{
    class Program
    {
        private static int[] tempArray;
        private static int[] matrixSizes;
        private static int[,] matrix;
        private static bool[,] usedIndexes;
        private static int bestLength;
        private static int currentLength;

        static void Main(string[] args)
        {
            matrixSizes = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
            matrix = new int[matrixSizes[0], matrixSizes[1]];
            usedIndexes = new bool[matrixSizes[0], matrixSizes[1]];


            for (int row = 0; row < matrixSizes[0]; row++)
            {
                tempArray = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
                for (int col = 0; col < matrixSizes[1]; col++)
                {
                    matrix[row, col] = tempArray[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    currentLength = 0;
                    Program.DFS(row, col, matrix[row, col]);
                }
            }

            Console.WriteLine(bestLength);
        }

        private static void DFS(int row, int col, int targetValue)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }
            if (usedIndexes[row, col])
            {
                return;
            }
            if (matrix[row, col] != targetValue)
            {
                return;
            }

            currentLength++;
            bestLength = currentLength > bestLength ? currentLength : bestLength;
            usedIndexes[row, col] = true;

            Program.DFS(row + 1, col, targetValue);
            Program.DFS(row - 1, col, targetValue);
            Program.DFS(row, col + 1, targetValue);
            Program.DFS(row, col - 1, targetValue);

        }
    }
}