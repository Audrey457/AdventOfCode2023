using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day2
{
    public class ColorSet
    {
        public int Blue { get; set; }
        public int Green { get; set; }
        public int Red { get; set;  }

        public ColorSet()
        {
            
        }

        public ColorSet(int blue, int green, int red)
        {
            Blue = blue;
            Green = green;
            Red = red;
        }

        public override string ToString()
        {
            return "Blue : " + this.Blue + " Green : " + this.Green + " Red : " + this.Red;
        }

        public int Power()
        {
            return Blue * Green * Red;
        }
    }

    public class ColorValue
    { 
        public int Value { get; set; }
        public string Color { get; set; }
    }

    public class PowerColorSetCalculator 
    {
        public string[] Games { get; set; }
        public PowerColorSetCalculator()
        {
            
        }

        public PowerColorSetCalculator(string[] games)
        {
            this.Games = games;
        }


        private List<ColorValue> GetColorValues(string game) 
        {
            //[1 green][2 blue]
            string[] colors = game.Trim().Split(',');
            return colors.Select(x => new ColorValue { Color = x.Trim().Split(' ')[1], Value = Int32.Parse(x.Trim().Split(' ')[0].Trim()) }).ToList();
        }

        public List<ColorValue> GetGamesColorValues()
        {
            var colorValues = new List<ColorValue>();
            foreach (var item in Games)
            {
                colorValues.AddRange(GetColorValues(item));
            }
            return colorValues;
        }

        public ColorSet CalculateFewestColorSet()
        {
            var colorValues = GetGamesColorValues();
            int blue = colorValues.Where(x => x.Color.Contains("blue", StringComparison.OrdinalIgnoreCase)).Max(x => x.Value);
            int green = colorValues.Where(x => x.Color.Contains("green", StringComparison.OrdinalIgnoreCase)).Max(x => x.Value);
            int red = colorValues.Where(x => x.Color.Contains("red", StringComparison.OrdinalIgnoreCase)).Max(x => x.Value);

            return new ColorSet(blue, green, red);
        }
    }
}
