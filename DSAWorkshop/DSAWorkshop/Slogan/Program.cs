using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slogan
{
    class Program
    {
        private static HashSet<string> currentSloganWords;
        private static string currentSlogan;
        private static StringBuilder currentlyFormedSlogan = new StringBuilder();
        private static StringBuilder currentlyFormedSloganWithSpaces = new StringBuilder();
        private static StringBuilder foundedSlogans = new StringBuilder();
        private static bool mustBreak;

        public static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                currentSloganWords = new HashSet<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                currentSlogan = Console.ReadLine();
                FindSloganRecursive(ref mustBreak, 0);
                if (mustBreak)
                {
                    Console.WriteLine(currentlyFormedSloganWithSpaces.ToString().Trim());
                    mustBreak = false;
                }
                else
                {
                    Console.WriteLine("NOT VALID");
                }
                currentlyFormedSlogan.Clear();
                currentlyFormedSloganWithSpaces.Clear();
            }
        }



        private static void FindSloganRecursive(ref bool mustBreak, int currentPosition)
        {
            for (int usedLetters = 1; usedLetters <= currentSlogan.Length; usedLetters++)
            {
                if (currentPosition + usedLetters > currentSlogan.Length)
                {
                    if (currentPosition == currentSlogan.Length)
                    {
                        if (currentlyFormedSlogan.ToString().Equals(currentSlogan))
                        {
                            foundedSlogans.AppendLine(currentlyFormedSlogan.ToString());
                            mustBreak = true;
                            return;
                        }
                    }
                    if (currentlyFormedSlogan.Length != 0)
                    {
                        int tempValue = currentPosition >= currentlyFormedSlogan.Length ? currentlyFormedSlogan.Length - 1 : currentPosition;
                        currentlyFormedSlogan = currentlyFormedSlogan.Remove(tempValue, currentlyFormedSlogan.Length - tempValue);
                        currentlyFormedSloganWithSpaces = currentlyFormedSloganWithSpaces.Remove(tempValue, currentlyFormedSlogan.Length - tempValue + 1);
                    }
                    return;
                }
                if (!currentSloganWords.Contains(currentSlogan.Substring(currentPosition, usedLetters)))
                {
                    continue;
                }
                currentlyFormedSlogan.Append(currentSlogan.Substring(currentPosition, usedLetters));
                currentlyFormedSloganWithSpaces.Append(currentSlogan.Substring(currentPosition, usedLetters) + " ");
                FindSloganRecursive(ref mustBreak, currentPosition + usedLetters);
                if (mustBreak)
                {
                    return;
                }
            }
        }
    }
}