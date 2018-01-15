using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaInMatrix
{
    class Program
    {
        private static int[,] matrix;
        private static bool[,] boolMatrix;
        private static int bestCount;
        private static int tempCount;

        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
            matrix = new int[rowAndCol[0], rowAndCol[1]];
            boolMatrix = new bool[rowAndCol[0], rowAndCol[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRowValues = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRowValues[j];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    DFS(matrix[row, col], row, col);
                    if (tempCount > bestCount)
                    {
                        bestCount = tempCount;
                    }
                    tempCount = 0;
                }
            }

            Console.WriteLine(bestCount);
            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        Console.Write(matrix[row, col] + " ");
            //    }
            //    Console.WriteLine();
            //}
        }

        private static void DFS(int currentCheckedElement, int currentRow, int currentCol)
        {
            if (currentRow < 0 || currentRow >= matrix.GetLength(0) || currentCol < 0 || currentCol >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[currentRow, currentCol] != currentCheckedElement)
            {
                return;
            }

            if (boolMatrix[currentRow, currentCol])
            {
                return;
            }

            boolMatrix[currentRow, currentCol] = true;
            tempCount++;

            DFS(currentCheckedElement, currentRow - 1, currentCol);
            DFS(currentCheckedElement, currentRow + 1, currentCol);
            DFS(currentCheckedElement, currentRow, currentCol - 1);
            DFS(currentCheckedElement, currentRow, currentCol + 1);
        }
    }
}