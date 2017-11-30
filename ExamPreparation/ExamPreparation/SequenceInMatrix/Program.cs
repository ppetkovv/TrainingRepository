using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceInMatrix
{
    class Program
    {
        private static int[,] matrix;
        private static int bestLength = 1;
        private static int currentLength = 1;
        private static int[] sizesOfMatrix;
        private static int[] tempArray;

        static void Main(string[] args)
        {
            sizesOfMatrix = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
            matrix = new int[sizesOfMatrix[0], sizesOfMatrix[1]];

            for (int row = 0; row < sizesOfMatrix[0]; row++)
            {
                tempArray = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
                for (int col = 0; col < sizesOfMatrix[1]; col++)
                {
                    matrix[row, col] = tempArray[col];
                }
            }

            Program.CheckHorizontals();
            Program.CheckVerticals();
            Program.CheckLeftDiagonals();
            Program.CheckRightDiagonals();

            Console.WriteLine(bestLength);
        }

        private static void CheckRightDiagonals()
        {
            for (int col = matrix.GetLength(1) - 2; col >= 0; col--)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    if (matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        CheckForBestLength();
                    }
                }
                CheckForBestLength();
            }
        }

        private static void CheckLeftDiagonals()
        {
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    if (matrix[row, col] == matrix[row + 1, col - 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        CheckForBestLength();
                    }
                }
                CheckForBestLength();
            }
        }

        private static void CheckVerticals()
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    if (matrix[row, col] == matrix[row + 1, col])
                    {
                        currentLength++;
                    }
                    else
                    {
                        CheckForBestLength();
                    }
                }
                CheckForBestLength();
            }
        }

        private static void CheckHorizontals()
        {
            for (int row = 0; row < sizesOfMatrix[0]; row++)
            {
                for (int col = 0; col < sizesOfMatrix[1] - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        CheckForBestLength();
                    }
                }
                CheckForBestLength();
            }
        }

        private static void CheckForBestLength()
        {
            if (currentLength != 1 && currentLength > bestLength)
            {
                bestLength = currentLength;
            }
            currentLength = 1;
        }
    }
}