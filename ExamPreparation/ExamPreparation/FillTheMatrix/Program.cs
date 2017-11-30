using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheMatrix
{
    class Program
    {
        private static int[,] matrix;
        private static int counter = 1;
        private static int row = 0;
        private static int col = 0;

        static void Main(string[] args)
        {
            //First Task

            int n = Int32.Parse(Console.ReadLine());
            matrix = new int[n, n];
            char fillVariant = Console.ReadLine()[0];

            switch (fillVariant)
            {
                case 'a':
                    FillMatrixA();
                    break;
                case 'b':
                    FillTheMatrixB();
                    break;
                case 'c':
                    FillMatrixC();
                    break;
                case 'd':
                    FillTheMatrixD();
                    break;
                default:
                    throw new ArgumentException();
            }

            PrintMatrix();
        }

        private static void FillMatrixA()
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = counter++;
                }
            }
        }

        private static void FillTheMatrixB()
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, col] = counter++;
                    }
                }
                else
                {
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        matrix[row, col] = counter++;
                    }
                }
            }
        }

        private static void FillMatrixC()
        {
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int secondRow = row, col = 0; secondRow < matrix.GetLength(0); secondRow++, col++)
                {
                    matrix[secondRow, col] = counter++;
                }
            }

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                for (int secondCol = col, row = 0; secondCol < matrix.GetLength(1); secondCol++, row++)
                {
                    matrix[row, secondCol] = counter++;
                }
            }
        }

        private static void FillTheMatrixD()
        {
            bool isDown = true;
            bool isRight = false;
            bool isUp = false;
            bool isLeft = false;

            while (counter <= matrix.GetLength(0) * matrix.GetLength(1))
            {
                matrix[row, col] = counter++;
                if (isDown)
                {
                    if (row + 1 >= matrix.GetLength(0) || matrix[row + 1, col] != 0)
                    {
                        col++;
                        isDown = false;
                        isRight = true;
                    }
                    else
                    {
                        row++;
                    }
                }
                else if (isRight)
                {
                    if (col + 1 >= matrix.GetLength(1) || matrix[row, col + 1] != 0)
                    {
                        row--;
                        isRight = false;
                        isUp = true;
                    }
                    else
                    {
                        col++;
                    }
                }
                else if (isUp)
                {
                    if (row - 1 < 0 || matrix[row - 1, col] != 0)
                    {
                        col--;
                        isUp = false;
                        isLeft = true;
                    }
                    else
                    {
                        row--;
                    }
                }
                else if (isLeft)
                {
                    if (col - 1 < 0 || matrix[row, col - 1] != 0)
                    {
                        row++;
                        isLeft = false;
                        isDown = true;
                    }
                    else
                    {
                        col--;
                    }
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write(matrix[row, 0]);
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    Console.Write(" " + matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}