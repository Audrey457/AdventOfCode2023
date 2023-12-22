using System.Text;

namespace AdventOfCode2023.Day3
{
    public class DetectPartNumber
    {
        private readonly char[][] matrice;

        public DetectPartNumber(char[][] matrice)
        {
            this.matrice = matrice;
        }

        public List<int> GetParts()
        {
            List<int> parts = new List<int>();
            int i = 0;
            foreach(char[]line in matrice)
            {
                parts.AddRange(DetectLinePartNumber(line, i).Values);
                i++;
            }
            return parts;
        }

        private Dictionary<int, int> DetectLinePartNumber(char[] line, int lineNumber)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            var h = DetectHorizontal(line);


            return h.Concat(DetectVertical(line, lineNumber).Where(x => !h.ContainsKey(x.Key))).ToDictionary();
        }

        private Dictionary<int, int> DetectHorizontal(char[] line)
        {
            int i=0;
            int pos;
            string numberToAdd;
            Dictionary<int, int> result = new Dictionary<int, int>();
            foreach (char c in line)
            {
                numberToAdd = "";
                if (char.IsNumber(c))
                {
                    if (i != 0 && !char.IsNumber(line[i - 1]) && !(line[i - 1].Equals('.'))) {
                        pos = i;
                        while (pos < line.Length && char.IsNumber(line[pos]))
                        {
                            numberToAdd += line[pos];
                            pos++;
                        }
                        result[i]= Int32.Parse(numberToAdd);
                    }
                    else if(i != line.Length -1 && !char.IsNumber(line[i + 1]) && !(line[i + 1].Equals('.')))
                    {
                        pos = i;
                        while (pos >= 0 && char.IsNumber(line[pos]))
                        {
                            numberToAdd += line[pos];
                            pos--;
                        }
                        result[pos+1] = Int32.Parse(new string(numberToAdd.Reverse().ToArray()));
                    }
                }
                i++;
            }
            return result;
        }
        private Dictionary<int, int> DetectVertical(char[] line, int lineNumber)
        {
            int pos;
            int next = 0;
            StringBuilder numberToAdd = new StringBuilder();
            Dictionary<int, int> result = new Dictionary<int, int>();
            
            //foreach (char c in line)
            for(int i = 0; i < line.Length; i++)
            {
                if (char.IsNumber(line[i]))
                {
                    if ((lineNumber != 0 && IsImmediateAboveSymbol(lineNumber, i)) ||
                        (lineNumber != matrice.Length - 1 && isImmediateBelowSymbol(lineNumber, i)))
                    {
                        pos = i;
                        next = BuildNumber(line, i, pos, numberToAdd);
                        result[next - numberToAdd.Length] = Int32.Parse(numberToAdd.ToString());
                        numberToAdd.Clear();
                        i = next;
                    }
                }
            }
            return result;
        }

        private bool IsImmediateAboveSymbol(int lineNumber, int i)
        {
            return AboveIsSymbol(lineNumber, i) || AboveLeftDiagIsSymbol(lineNumber, i) || AboveRightDiagIsSymbol(lineNumber, i);
        }

        private bool isImmediateBelowSymbol(int lineNumber, int i)
        {
            return BelowIsSymbol(lineNumber, i) || BelowLeftDiagIsSymbol(lineNumber, i) || BelowRightDiagIsSymbol(lineNumber, i);
        }

        private bool AboveIsSymbol(int lineNumber, int i)
        {
            return !char.IsNumber(matrice[lineNumber - 1][i]) && !(matrice[lineNumber - 1][i].Equals('.'));
        }

        private bool AboveLeftDiagIsSymbol(int lineNumber, int i)
        {
            return i > 0 && !char.IsNumber(matrice[lineNumber - 1][i-1]) && !(matrice[lineNumber - 1][i-1].Equals('.'));
        }

        private bool AboveRightDiagIsSymbol(int lineNumber, int i)
        {
            return i < matrice[lineNumber].Length-1 && !char.IsNumber(matrice[lineNumber - 1][i + 1]) && !(matrice[lineNumber - 1][i + 1].Equals('.'));
        }

        private bool BelowIsSymbol(int lineNumber, int i)
        {
            return !char.IsNumber(matrice[lineNumber + 1][i]) && !(matrice[lineNumber + 1][i].Equals('.'));
        }

        private bool BelowLeftDiagIsSymbol(int lineNumber, int i)
        {
            return i > 0 && !char.IsNumber(matrice[lineNumber + 1][i - 1]) && !(matrice[lineNumber + 1][i - 1].Equals('.'));
        }

        private bool BelowRightDiagIsSymbol(int lineNumber, int i)
        {
            return i < matrice[lineNumber].Length-1 && !char.IsNumber(matrice[lineNumber + 1][i + 1]) && !(matrice[lineNumber + 1][i + 1].Equals('.'));
        }

        private static int BuildNumber(char[] line, int i, int pos, StringBuilder numberToAdd)
        {
            int next;
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
