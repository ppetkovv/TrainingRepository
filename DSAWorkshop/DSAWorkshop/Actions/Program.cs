//Solution One - LinkedList - 100 points

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Actions
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arrayOfInts = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
//            LinkedList<int> linkedList = new LinkedList<int>();
//            Dictionary<int, LinkedListNode<int>> dictionary = new Dictionary<int, LinkedListNode<int>>();

//            for (int i = 0; i < arrayOfInts[0]; i++)
//            {
//                dictionary.Add(i, new LinkedListNode<int>(i));
//                linkedList.AddLast(dictionary[i]);
//            }

//            int[] currentPriority;
//            int firstElement;
//            int secondElement;

//            for (int i = 0; i < arrayOfInts[1]; i++)
//            {
//                currentPriority = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
//                firstElement = currentPriority[0];
//                secondElement = currentPriority[1];

//                bool needChanges = true;

//                LinkedListNode<int> currNode = dictionary[secondElement];
//                while (currNode != null)
//                {
//                    if (currNode.Value == firstElement)
//                    {
//                        needChanges = false;
//                        break;
//                    }
//                    currNode = currNode.Previous;
//                }

//                if (needChanges)
//                {
//                    LinkedListNode<int> elementForReplacing = dictionary[secondElement];
//                    linkedList.Remove(elementForReplacing);

//                    LinkedListNode<int> border = dictionary[firstElement];
//                    while (border.Next != null && border.Next.Value < elementForReplacing.Value)
//                    {
//                        border = border.Next;
//                    }
//                    linkedList.AddAfter(border, elementForReplacing);
//                }
//            }

//            foreach (var item in linkedList)
//            {
//                Console.WriteLine(item);
//            }

//        }
//    }
//}

//Solution Two - Topological Sorting Simple Data Structures - 100 points

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Actions
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arrayOfInts = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();

//            List<int>[] parents = new List<int>[arrayOfInts[0]];
//            int[] children = new int[arrayOfInts[0]];
//            bool[] visited = new bool[arrayOfInts[0]];

//            int[] tempValues;
//            int parent;
//            int child;
//            for (int i = 0; i < arrayOfInts[1]; i++)
//            {
//                tempValues = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
//                parent = tempValues[0];
//                child = tempValues[1];

//                if (parents[parent] == null)
//                {
//                    parents[parent] = new List<int>();
//                }

//                parents[parent].Add(child);
//                children[child]++;
//            }

//            for (int i = 0; i < parents.Length; i++)
//            {
//                if (parents[i] == null)
//                {
//                    parents[i] = new List<int>();
//                }
//            }

//            for (int i = 0; i < children.Length; i++)
//            {
//                if (children[i] == 0 && !visited[i])
//                {
//                    Console.WriteLine(i);
//                    visited[i] = true;
//                    for (int j = 0; j < parents[i].Count; j++)
//                    {
//                        int parentCurrentChild = parents[i][j];
//                        children[parentCurrentChild]--;
//                    }
//                    i = -1;
//                }
//            }

//        }
//    }
//}