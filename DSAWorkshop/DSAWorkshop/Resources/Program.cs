using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());

            Dictionary<string, List<string>> priorityResources = new Dictionary<string, List<string>>();
            SortedDictionary<string, int> secondaryResources = new SortedDictionary<string, int>();
            Dictionary<string, bool> visited = new Dictionary<string, bool>();

            string[] currentInputLine;
            string priorityResource;
            string secondaryResource;

            for (int i = 0; i < N; i++)
            {
                currentInputLine = Console.ReadLine().Split().ToArray();
                secondaryResource = currentInputLine[2];
                priorityResource = currentInputLine[0];

                if (!priorityResources.ContainsKey(priorityResource))
                {
                    priorityResources.Add(priorityResource, new List<string>());
                }
                priorityResources[priorityResource].Add(secondaryResource);

                if (!secondaryResources.ContainsKey(secondaryResource))
                {
                    secondaryResources.Add(secondaryResource, 0);
                    visited.Add(secondaryResource, false);
                }
                secondaryResources[secondaryResource] += 1;

                if (!secondaryResources.ContainsKey(priorityResource))
                {
                    secondaryResources.Add(priorityResource, 0);
                    visited.Add(priorityResource, false);
                }
            }

            List<string> result = new List<string>();
            while (!visited.All(x => x.Value))
            {
                foreach (var item in secondaryResources)
                {
                    if (item.Value == 0 && !visited[item.Key])
                    {
                        result.Add(item.Key);
                        visited[item.Key] = true;

                        if (priorityResources.ContainsKey(item.Key))
                        {
                            foreach (var item2 in priorityResources[item.Key])
                            {
                                secondaryResources[item2] -= 1;
                            }
                        }
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}