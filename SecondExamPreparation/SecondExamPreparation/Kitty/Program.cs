using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitty
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] elements = Console.ReadLine().ToArray();
            int[] moves = Console.ReadLine().Split().Select(Int32.Parse).ToArray();

            int currentMove = 0;
            int currentIndex = 0;

            int soulsCount = 0;
            int foodsCount = 0;
            int deadLocks = 0;

            switch (elements[currentIndex])
            {
                case '@':
                    elements[currentIndex] = '\u0000';
                    soulsCount++;
                    break;
                case '*':
                    elements[currentIndex] = '\u0000';
                    foodsCount++;
                    break;
                case 'x':
                    deadLocks++;
                    if (currentIndex % 2 == 0)
                    {
                        if (soulsCount - 1 < 0)
                        {
                            Console.WriteLine(string.Format("You are deadlocked, you greedy kitty!\nJumps before deadlock: {0}", 0));
                            return;
                        }
                        else
                        {
                            soulsCount--;
                            elements[currentIndex] = '@';
                        }
                    }
                    else
                    {
                        if (foodsCount - 1 < 0)
                        {
                            Console.WriteLine(string.Format("You are deadlocked, you greedy kitty!\nJumps before deadlock: {0}", 0));
                            return;
                        }
                        else
                        {
                            foodsCount--;
                            elements[currentIndex] = '*';
                        }
                    }
                    break;
                default:
                    break;
            }

            for (int i = 0; i < moves.Length; i++)
            {
                currentMove = moves[i];
                currentIndex += currentMove;

                while (currentIndex < 0)
                {
                    currentIndex = elements.Length + currentIndex;
                }
                while (currentIndex > elements.Length - 1)
                {
                    currentIndex = currentIndex - elements.Length;
                }

                switch (elements[currentIndex])
                {
                    case '@':
                        elements[currentIndex] = '\u0000';
                        soulsCount++;
                        break;
                    case '*':
                        elements[currentIndex] = '\u0000';
                        foodsCount++;
                        break;
                    case 'x':
                        deadLocks++;
                        if (currentIndex % 2 == 0)
                        {
                            if (soulsCount - 1 < 0)
                            {
                                Console.WriteLine(string.Format("You are deadlocked, you greedy kitty!\nJumps before deadlock: {0}", i + 1));
                                return;
                            }
                            else
                            {
                                soulsCount--;
                                elements[currentIndex] = '@';
                            }
                        }
                        else
                        {
                            if (foodsCount - 1 < 0)
                            {
                                Console.WriteLine(string.Format("You are deadlocked, you greedy kitty!\nJumps before deadlock: {0}", i + 1));
                                return;
                            }
                            else
                            {
                                foodsCount--;
                                elements[currentIndex] = '*';
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Format("Coder souls collected: {0}\nFood collected: {1}\nDeadlocks: {2}", soulsCount, foodsCount, deadLocks));
        }
    }
}