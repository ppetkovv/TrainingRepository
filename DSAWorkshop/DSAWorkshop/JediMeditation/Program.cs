using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());
            string[] allJedis = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Queue<string> jediMasters = new Queue<string>();
            Queue<string> jediKnights = new Queue<string>();
            Queue<string> jediPadawans = new Queue<string>();

            for (int i = 0; i < allJedis.Length; i++)
            {
                if (allJedis[i][0].Equals('M'))
                {
                    jediMasters.Enqueue(allJedis[i]);
                }
                else if (allJedis[i][0].Equals('K'))
                {
                    jediKnights.Enqueue(allJedis[i]);
                }
                else if (allJedis[i][0].Equals('P'))
                {
                    jediPadawans.Enqueue(allJedis[i]);
                }
            }

            StringBuilder result = new StringBuilder();
            foreach (var item in jediMasters)
            {
                result.Append(item + " ");
            }
            foreach (var item in jediKnights)
            {
                result.Append(item + " ");
            }
            foreach (var item in jediPadawans)
            {
                result.Append(item + " ");
            }
            Console.WriteLine(result.ToString().Trim());
        }
    }
}