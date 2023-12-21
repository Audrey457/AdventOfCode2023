using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day2
{
    public static class Day2
    {
        static int maxBlue = 14;
        static int maxGreen = 13;
        static int maxRed = 12;
        
        

        public static int GetPossibleGamesTotalIds()
        {
            int total = 0;
            using (var sr = new StreamReader(@"C:\Users\310616706\source\repos\AdventOfCode2023\AdventOfCode2023\Day2\Input.txt"))
            {
                while (!sr.EndOfStream) {
                    string[] splitedGame = sr.ReadLine().Split(':');
                    if (isPossibleGame(splitedGame[1])) {
                        total += Int32.Parse(splitedGame[0].Trim().Split(' ')[1].Trim());
                    }
                }
            }
            return total;
        }

        public static int GetPowerSum()
        {
            int powerSum = 0;
            PowerColorSetCalculator powerColorSetCalculator = new PowerColorSetCalculator();
            using (var sr = new StreamReader(@"C:\Users\310616706\source\repos\AdventOfCode2023\AdventOfCode2023\Day2\Input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    powerColorSetCalculator.Games = sr.ReadLine().Split(':')[1].Split(";");
                    powerSum += powerColorSetCalculator.CalculateFewestColorSet().Power();
                }
            }
            return powerSum;
        }
        static bool isPossibleGame(string game)
        {
            string[] games = game.Split(';');
            foreach (string g in games)
            {
                if (!isPossibleHandful(g))
                {
                    return false;
                }
            }
            return true;
        }
        static bool isPossible(int nbOfBlue, int nbOfGreen, int nbOfRed)
        {
            return nbOfBlue <= maxBlue && nbOfGreen <= maxGreen && nbOfRed <= maxRed;
        }

        static bool isPossibleHandful(string handfull)
        {
            var colors = handfull.Split(',');
            int blue = getNumberOfColor("blue", colors);
            int green = getNumberOfColor("green", colors);
            int red = getNumberOfColor("red", colors);
            return isPossible(blue,green,red);
        }

        static int getNumberOfColor(string color, string[] colors)
        {
            if (!string.IsNullOrEmpty(colors.FirstOrDefault(col => col.Contains(color))))
            {
                return Int32.Parse(colors.First(col => col.Contains(color)).Trim().Split(' ')[0]);
            }
            return 0;
        }
    }
}
