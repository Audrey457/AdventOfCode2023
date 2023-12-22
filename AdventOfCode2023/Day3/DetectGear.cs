using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day3
{
    public class DetectGear
    {
        private readonly char[][] matrice;

        public DetectGear(char[][] matrice)
        {
            this.matrice = matrice;
        }

        public int GetSum()
        {
            int sum = 0;
            for(int i = 0; i < matrice.Length; i++)
            {
                sum += GetLineRatio(i);
            }
            return sum;
        }

        public int GetLineRatio(int lineNumber)
        {
            int result = 0;
            foreach(int gear in PotentialGearPositions(lineNumber))
            {
                result += GetGearRatio(lineNumber, gear);
            }
            return result;
        }

        public int GetGearRatio(int lineNumber, int gear)
        {
            int result = 0;
            List<string> total = new List<string>();
            total.Add(GetNumberAboveLeft(lineNumber, gear));
            total.Add(GetNumberAbove(lineNumber, gear));
            total.Add(GetNumberAboveRight(lineNumber, gear));
            total.Add(GetNumberLeft(lineNumber, gear));
            total.Add(GetNumberRight(lineNumber, gear));
            total.Add(GetNumberBelowLeft(lineNumber, gear));
            total.Add(GetNumberBelow(lineNumber, gear));
            total.Add(GetNumberBelowRight(lineNumber, gear));
            var notEmpty = total.Where(n => !string.IsNullOrEmpty(n)).ToList();
            if (notEmpty.Count == 2)
            {
                result = notEmpty.Select(n => Int32.Parse(n)).Aggregate((x, y) => x * y);
            }
            return result;
        }

        public List<int> PotentialGearPositions(int lineNumber)
        {
            List<int> positions = new List<int>();   
            for(int i = 0; i < matrice[lineNumber].Length; i++)
            {
                if (matrice[lineNumber][i] == '*') { positions.Add(i); }
            }
            return positions;
        }

        public string GetNumberLeft(int lineNumber, int potentialGear)
        {
            if (!HasNumberLeft(lineNumber, potentialGear))
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            BuildNumber(matrice[lineNumber], potentialGear - 1, sb);
            return sb.ToString();
        }

        public bool HasNumberLeft(int lineNumber, int charPosition)
        {
            return charPosition > 0 &&  char.IsNumber(matrice[lineNumber][charPosition-1]);
        }

        public string GetNumberRight(int lineNumber, int potentialGear)
        {
            if(!HasNumberRight(lineNumber, potentialGear))
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            BuildNumber(matrice[lineNumber], potentialGear + 1, sb);
            return sb.ToString();
        }

        public bool HasNumberRight(int lineNumber, int potentialGear)
        {
            return potentialGear < matrice[lineNumber].Length-1 && char.IsNumber(matrice[lineNumber][potentialGear + 1]);
        }

        public string GetNumberAbove(int lineNumber, int potentialGear)
        {
            if(!HasNumberAbove(lineNumber, potentialGear))
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            BuildNumber(matrice[lineNumber-1], potentialGear, sb);
            return sb.ToString();

        }

        public bool HasNumberAbove(int lineNumber, int potentialGear)
        {
            int aboveLineNumber = lineNumber - 1;
            return lineNumber > 0 &&  char.IsNumber(matrice[aboveLineNumber][potentialGear]) ;
        }

        public string GetNumberAboveLeft(int lineNumber, int potentialGear)
        {
            if (!HasNumberAboveLeft(lineNumber, potentialGear))
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            BuildNumber(matrice[lineNumber - 1], potentialGear-1, sb);
            return sb.ToString();
        }

        public bool HasNumberAboveLeft(int lineNumber, int potentialGear)
        {
            int aboveLineNumber = lineNumber - 1;
            return lineNumber > 0 &&
                !char.IsNumber(matrice[aboveLineNumber][potentialGear]) && 
                potentialGear > 0 &&
                char.IsNumber(matrice[aboveLineNumber][potentialGear-1]);
        }

        public string GetNumberAboveRight(int lineNumber, int potentialGear)
        {
            if (!HasNumberAboveRight(lineNumber, potentialGear))
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            BuildNumber(matrice[lineNumber - 1], potentialGear + 1, sb);
            return sb.ToString();
        }

        public bool HasNumberAboveRight(int lineNumber, int potentialGear)
        {
            int aboveLineNumber = lineNumber - 1;
            return lineNumber > 0 && 
                potentialGear < matrice[aboveLineNumber].Length-1 &&
                !char.IsNumber(matrice[aboveLineNumber][potentialGear]) && 
                char.IsNumber(matrice[aboveLineNumber][potentialGear + 1]);
        }

        public string GetNumberBelow(int lineNumber, int potentialGear)
        {
            if (!HasNumberBelow(lineNumber, potentialGear))
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            BuildNumber(matrice[lineNumber + 1], potentialGear, sb);
            return sb.ToString();

        }

        public bool HasNumberBelow(int lineNumber, int potentialGear)
        {
            int belowLineNumber = lineNumber + 1;
            return lineNumber < matrice.Length-1 && char.IsNumber(matrice[belowLineNumber][potentialGear]);
        }

        public string GetNumberBelowRight(int lineNumber, int potentialGear)
        {
            if (!HasNumberBelowRight(lineNumber, potentialGear))
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            BuildNumber(matrice[lineNumber + 1], potentialGear + 1, sb);
            return sb.ToString();
        }

        public bool HasNumberBelowRight(int lineNumber, int potentialGear)
        {
            int belowLineNumber = lineNumber + 1;
            return lineNumber < matrice.Length - 1 &&
                potentialGear < matrice[belowLineNumber].Length - 1 &&
                !char.IsNumber(matrice[belowLineNumber][potentialGear]) &&
                char.IsNumber(matrice[belowLineNumber][potentialGear + 1]);
        }

        public string GetNumberBelowLeft(int lineNumber, int potentialGear)
        {
            if (!HasNumberBelowLeft(lineNumber, potentialGear))
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            BuildNumber(matrice[lineNumber + 1], potentialGear - 1, sb);
            return sb.ToString();
        }

        public bool HasNumberBelowLeft(int lineNumber, int potentialGear)
        {
            int belowLineNumber = lineNumber + 1;
            return lineNumber < matrice.Length - 1 &&
                !char.IsNumber(matrice[belowLineNumber][potentialGear]) &&
                potentialGear > 0 &&
                char.IsNumber(matrice[belowLineNumber][potentialGear - 1]);
        }


        private static int BuildNumber(char[] line, int i, StringBuilder numberToAdd)
        {
            int next;
            int pos = i;
            while (pos < line.Length && char.IsNumber(line[pos]))
            {
                numberToAdd.Append(line[pos]);
                pos++;
            }
            next = pos;
            pos = i - 1;
            while (pos >= 0 && char.IsNumber(line[pos]))
            {
                numberToAdd.Insert(0, line[pos]);
                pos--;
            }
            return next;
        }
    }
}
