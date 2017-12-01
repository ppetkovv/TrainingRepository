using System;
using System.Numerics;
using System.Linq;

namespace SecondExamPreparation
{
    class BitShiftMatrix
    {
        public static void Main(string[] args)
        {
            int rowsCount = Int32.Parse(Console.ReadLine());
            int colsCount = Int32.Parse(Console.ReadLine());

            BigInteger[,] matrix = new BigInteger[rowsCount, colsCount];

            int mainCounter = -1;
            int currentCounter = 0;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                mainCounter++;
                currentCounter = mainCounter;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = (BigInteger)Math.Pow(2, currentCounter);
                    currentCounter++;
                }
            }


            int movesCount = Int32.Parse(Console.ReadLine());
            int[] moves = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
            int coef = Math.Max(rowsCount, colsCount);
            int targetRow = 0;
            int targetCol = 0;
            int currentRow = matrix.GetLength(0) - 1;
            int currentCol = 0;
            BigInteger sum = 0;

            for (int i = 0; i < movesCount; i++)
            {
                targetRow = moves[i] / coef;
                targetCol = moves[i] % coef;

                if (targetCol < currentCol)
                {
                    for (int colIndex = currentCol; colIndex >= targetCol; colIndex--)
                    {
                        sum += matrix[currentRow, colIndex];
                        matrix[currentRow, colIndex] = 0;
                    }
                }
                else
                {
                    for (int colIndex = currentCol; colIndex <= targetCol; colIndex++)
                    {
                        sum += matrix[currentRow, colIndex];
                        matrix[currentRow, colIndex] = 0;
                    }
                }
                currentCol = targetCol;

                if (targetRow < currentRow)
                {
                    for (int rowIndex = currentRow; rowIndex >= targetRow; rowIndex--)
                    {
                        sum += matrix[rowIndex, currentCol];
                        matrix[rowIndex, currentCol] = 0;
                    }
                }
                else
                {
                    for (int rowIndex = currentRow; rowIndex <= targetRow; rowIndex++)
                    {
                        sum += matrix[rowIndex, currentCol];
                        matrix[rowIndex, currentCol] = 0;
                    }
                }
                currentRow = targetRow;
            }

            Console.WriteLine(sum);
        }
    }
}