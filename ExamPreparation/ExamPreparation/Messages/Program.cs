using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numeralSystemValues = new List<string>() { "cad", "xoz", "nop", "cyk", "min", "mar", "kon", "iva", "ogi", "yan" };

            string firstNumberAsString = Console.ReadLine();
            string operation = Console.ReadLine();
            string secondNumberAsString = Console.ReadLine();

            List<string> firstNumberSplitted = new List<string>(Program.Split(firstNumberAsString, 3));
            List<string> secondNumberSplitted = new List<string>(Program.Split(secondNumberAsString, 3));

            StringBuilder firstNumberAsSequenceOfDigits = new StringBuilder();
            StringBuilder secondNumberAsSequenceOfDigits = new StringBuilder();

            for (int i = 0; i < firstNumberSplitted.Count; i++)
            {
                if (numeralSystemValues.Contains(firstNumberSplitted[i]))
                {
                    firstNumberAsSequenceOfDigits.Append(numeralSystemValues.IndexOf(firstNumberSplitted[i]));
                }
            }

            for (int i = 0; i < secondNumberSplitted.Count; i++)
            {
                if (numeralSystemValues.Contains(secondNumberSplitted[i]))
                {
                    secondNumberAsSequenceOfDigits.Append(numeralSystemValues.IndexOf(secondNumberSplitted[i]));
                }
            }
            BigInteger resultedNumber = 0;

            if (operation.Equals("-"))
                resultedNumber = BigInteger.Parse(firstNumberAsSequenceOfDigits.ToString()) - BigInteger.Parse(secondNumberAsSequenceOfDigits.ToString());
            else
                resultedNumber = BigInteger.Parse(firstNumberAsSequenceOfDigits.ToString()) + BigInteger.Parse(secondNumberAsSequenceOfDigits.ToString());

            string resultedNumberAsString = resultedNumber.ToString();
            StringBuilder resultedNumberAsStringBuilder = new StringBuilder();

            for (int i = 0; i < resultedNumberAsString.Length; i++)
            {
                resultedNumberAsStringBuilder.Append(numeralSystemValues[Int32.Parse(resultedNumberAsString[i].ToString())]);
            }

            Console.WriteLine(resultedNumberAsStringBuilder.ToString());
        }

        private static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}