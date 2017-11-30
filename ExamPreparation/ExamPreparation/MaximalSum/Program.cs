using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];

            int[] currentRowValues;
            for (int row = 0; row < matrixSizes[0]; row++)
            {
                currentRowValues = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
                for (int col = 0; col < matrixSizes[1]; col++)
                {
                    matrix[row, col] = currentRowValues[col];
                }
            }

            int currentSum = 0;
            int bestSum = Int32.MinValue;

            for (int row = 0; row < matrixSizes[0] - 2; row++)
            {
                for (int col = 0; col < matrixSizes[1] - 2; col++)
                {
                    currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                    }
                }
            }

            Console.WriteLine(bestSum);
        }
    }
}