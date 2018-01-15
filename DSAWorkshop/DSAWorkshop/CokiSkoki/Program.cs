using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokiSkoki
{
    class Program
    {
        static void Main(string[] args)
        {
            //First Solution - 80 points

            //int N = Int32.Parse(Console.ReadLine());
            //List<int> buildings = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();
            //if (buildings.Count != N)
            //    return;

            //List<int> lengthOfSequences = new List<int>();
            //int currentSequence = 0;
            //int currentMax = 0;
            //for (int i = 0; i < buildings.Count; i++)
            //{
            //    currentSequence = 0;
            //    currentMax = buildings[i];
            //    for (int j = i + 1; j < buildings.Count; j++)
            //    {
            //        if (buildings[j] > currentMax)
            //        {
            //            currentSequence++;
            //            currentMax = buildings[j];
            //        }
            //    }
            //    lengthOfSequences.Add(currentSequence);
            //}

            //Console.WriteLine(lengthOfSequences.Max() + "\n" + string.Join(" ", lengthOfSequences));


            //Second Solution - 100 points

            //int N = Int32.Parse(Console.ReadLine());
            //int[] buildingsHeights = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
            //int[] jumps = new int[buildingsHeights.Length];

            //int maxJump = 0;
            //for (int currentBuildingIndex = buildingsHeights.Length - 1; currentBuildingIndex >= 0; currentBuildingIndex--)
            //{
            //    jumps[currentBuildingIndex] = 1 + CheckNextBuildings(currentBuildingIndex, buildingsHeights, jumps);
            //    maxJump = Math.Max(maxJump, jumps[currentBuildingIndex]);
            //}

            //Console.WriteLine(maxJump);
            //Console.WriteLine(string.Join(" ", jumps));
        }

        //private static int CheckNextBuildings(int currentBuildingIndex, int[] buildingsHeights, int[] jumps)
        //{
        //    for (int nextBuildingIndex = currentBuildingIndex + 1; nextBuildingIndex < buildingsHeights.Length; nextBuildingIndex++)
        //    {
        //        if(buildingsHeights[currentBuildingIndex] < buildingsHeights[nextBuildingIndex])
        //        {
        //            return jumps[nextBuildingIndex];
        //        }
        //    }
        //    return -1;
        //}
    }
}