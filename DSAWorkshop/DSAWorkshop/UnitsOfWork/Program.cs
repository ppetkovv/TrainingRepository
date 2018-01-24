using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsOfWork
{
    class Program
    {
        private static StringBuilder finalResult = new StringBuilder();
        private static Dictionary<string, SortedSet<Unit>> allUnitsInGameByType = new Dictionary<string, SortedSet<Unit>>();
        private static Dictionary<string, Unit> allUnitsInGameByName = new Dictionary<string, Unit>();
        private static SortedSet<Unit> allUnitsInGameSortedByPower = new SortedSet<Unit>();

        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            string[] splittedCommand;
            for (; command != "end";)
            {
                splittedCommand = command.Split();
                switch (splittedCommand[0])
                {
                    case "add":
                        AddUnit(splittedCommand);
                        break;
                    case "remove":
                        RemoveUnitByName(splittedCommand);
                        break;
                    case "find":
                        FindUnitByType(splittedCommand);
                        break;
                    case "power":
                        PowerCommand(splittedCommand);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }

            Console.Write(finalResult);
        }

        private static void PowerCommand(string[] splittedCommand)
        {
            int numberOfUnits = Int32.Parse(splittedCommand[1]);
            if (allUnitsInGameSortedByPower.Count <= numberOfUnits)
            {
                finalResult.AppendLine(string.Format("RESULT: ") + string.Join(", ", allUnitsInGameSortedByPower));
            }
            else if (allUnitsInGameSortedByPower.Count > numberOfUnits)
            {
                finalResult.AppendLine(string.Format("RESULT: ") + string.Join(", ", allUnitsInGameSortedByPower.Take(numberOfUnits)));
            }
        }

        private static void FindUnitByType(string[] splittedCommand)
        {
            string searchedUnitsType = splittedCommand[1];
            if (allUnitsInGameByType.ContainsKey(searchedUnitsType))
            {
                finalResult.AppendLine(string.Format("RESULT: ") + string.Join(", ", allUnitsInGameByType[searchedUnitsType].Take(10)));
            }
            else
            {
                finalResult.AppendLine("RESULT: ");
            }
        }

        private static void RemoveUnitByName(string[] splittedCommand)
        {
            string unitForRemovingName = splittedCommand[1];
            if (allUnitsInGameByName.ContainsKey(unitForRemovingName))
            {
                Unit unitForRemoving = allUnitsInGameByName[unitForRemovingName];
                string unitForRemovingType = unitForRemoving.Type;
                allUnitsInGameByType[unitForRemovingType].Remove(unitForRemoving);
                allUnitsInGameByName.Remove(unitForRemovingName);
                allUnitsInGameSortedByPower.Remove(unitForRemoving);
                finalResult.AppendLine(string.Format("SUCCESS: {0} removed!", unitForRemovingName));
            }
            else
            {
                finalResult.AppendLine(string.Format("FAIL: {0} could not be found!", unitForRemovingName));
            }
        }

        private static void AddUnit(string[] splittedCommand)
        {
            string futureUnitName = splittedCommand[1];
            string futureUnitType = splittedCommand[2];

            if (!allUnitsInGameByName.ContainsKey(futureUnitName))
            {
                Unit newUnit = new Unit(futureUnitName, splittedCommand[2], Int32.Parse(splittedCommand[3]));
                allUnitsInGameByName.Add(futureUnitName, newUnit);
                allUnitsInGameSortedByPower.Add(newUnit);

                if (!allUnitsInGameByType.ContainsKey(futureUnitType))
                {
                    allUnitsInGameByType.Add(futureUnitType, new SortedSet<Unit>());
                    allUnitsInGameByType[futureUnitType].Add(newUnit);
                }
                else
                {
                    allUnitsInGameByType[futureUnitType].Add(newUnit);
                }

                finalResult.AppendLine(string.Format("SUCCESS: {0} added!", futureUnitName));
            }
            else
            {
                finalResult.AppendLine(string.Format("FAIL: {0} already exists!", futureUnitName));
            }
        }
    }

    struct Unit : IComparable<Unit>
    {
        private string name;
        private string type;
        private int attack;

        public Unit(string name, string type, int attack):this()
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get => this.name; set => this.name = value; }
        public string Type { get => this.type; set => this.type = value; }
        public int Attack { get => this.attack; set => this.attack = value; }

        public int CompareTo(Unit other)
        {
            int returnResult = other.attack.CompareTo(this.attack);
            if (returnResult == 0)
            {
                returnResult = this.name.CompareTo(other.name);
            }
            return returnResult;
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.name, this.type, this.attack);
        }
    }
}