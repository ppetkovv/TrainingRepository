using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BishopPathFinder
{
    class Program
    {
        private static int[] matrixSizes;
        private static int[,] matrix;
        private static int sum;
        private static int[] rowsIndexes = { -1, -1, 1, 1 };
        private static int[] colsIndexes = { 1, -1, -1 ,1 };
        private static int currentRow;
        private static int currentCol;
        private static int GetIndexes(string direction)
        {
            switch (direction)
            {
                case "UR":
                    return 0;
                case "RU":
                    return 0;
                case "UL":
                    return 1;
                case "LU":
                    return 1;
                case "DL":
                    return 2;
                case "LD":
                    return 2;
                case "DR":
                    return 3;
                case "RD":
                    return 3;
                default:
                    throw new ArgumentException();
            }
        }

        static void Main(string[] args)
        {
            matrixSizes = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
            matrix = new int[matrixSizes[0], matrixSizes[1]];

            int mainCounter = -3;
            int currentCounter = 0;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                mainCounter += 3;
                currentCounter = mainCounter;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentCounter;
                    currentCounter += 3;
                }
            }

            int N = Int32.Parse(Console.ReadLine());
            currentRow = matrix.GetLength(0) - 1;
            currentCol = 0;

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();
                string direction = input[0];
                int moves = Int32.Parse(input[1]);

                for (int j = 0; j < moves - 1; j++)
                {
                    currentRow += rowsIndexes[GetIndexes(direction)];
                    currentCol += colsIndexes[GetIndexes(direction)];

                    if (currentRow < 0 || currentRow >= matrix.GetLength(0) || currentCol < 0 || currentCol >= matrix.GetLength(1))
                    {
                        currentRow -= rowsIndexes[GetIndexes(direction)];
                        currentCol -= colsIndexes[GetIndexes(direction)];
                        break;
                    }

                    sum += matrix[currentRow, currentCol];
                    matrix[currentRow,currentCol] = 0;
                }
            }

            Console.WriteLine(sum);
            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        Console.Write(matrix[row,col]+" ");
            //    }
            //    Console.WriteLine();
            //}

        }
    }
}