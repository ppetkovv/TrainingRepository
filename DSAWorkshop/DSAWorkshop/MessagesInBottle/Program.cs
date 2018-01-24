using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MessagesInBottle
{
    class Program
    {
        private static string secretMessageAsString;
        private static Dictionary<string, char> dictionary;
        private static int finalCount = 0;
        private static List<string> decodedMessages;

        static void Main(string[] args)
        {
            secretMessageAsString = Console.ReadLine();
            string cipherAsString = Console.ReadLine();

            string[] cipher = Regex.Split(cipherAsString, "([A-Z][0-9]{1,})").Where(x => x != string.Empty).ToArray();
            dictionary = new Dictionary<string, char>();
            for (int i = 0; i < cipher.Length; i++)
            {
                dictionary.Add(cipher[i].Substring(1), cipher[i][0]);
            }


            decodedMessages = new List<string>();

            DecodeMessage(0, new StringBuilder());

            Console.WriteLine(finalCount);

            if (decodedMessages.Count != 0)
                Console.WriteLine(string.Join("\n", decodedMessages.OrderBy(x => x)));
        }

        private static void DecodeMessage(int currentPosition, StringBuilder currentMessage)
        {
            for (int usedDigits = 1; usedDigits <= secretMessageAsString.Length; usedDigits++)
            {
                if (currentPosition + usedDigits > secretMessageAsString.Length)
                {
                    if (currentPosition == secretMessageAsString.Length)
                    {
                        decodedMessages.Add(currentMessage.ToString());
                        finalCount++;
                    }
                    if (currentMessage.Length != 0)
                    {
                        int tempValue = currentPosition >= currentMessage.Length ? currentMessage.Length - 1 : currentPosition;
                        currentMessage = currentMessage.Remove(tempValue, currentMessage.Length - tempValue);
                    }
                    return;
                }
                if (!dictionary.ContainsKey(secretMessageAsString.Substring(currentPosition, usedDigits)))
                {
                    continue;
                }
                currentMessage.Append(dictionary[secretMessageAsString.Substring(currentPosition, usedDigits)]);
                DecodeMessage(currentPosition + usedDigits, currentMessage);
            }
        }
    }
}