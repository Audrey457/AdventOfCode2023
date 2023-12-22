namespace AdventOfCode2023.Day1
{
    public static class Day1
    {
        static Dictionary<string, char> dic = new Dictionary<string, char>
            {
                { "one", '1' },
                { "two", '2' },
                { "three", '3' },
                { "four", '4' },
                { "five", '5' },
                { "six", '6' },
                { "seven", '7' },
                { "eight", '8' },
                { "nine", '9' }
            };
        public static int GetCalibrationSum()
        {
            int total = 0;
            var sw = new StreamWriter(@"..\..\..\Day1\Output.txt");
            using (var sr = new StreamReader(@"..\..\..\Day1\Input.txt"))
            {
                while (!sr.EndOfStream)
                {

                    total += GetNumber(sr.ReadLine(), sw);
                    sw.WriteLine(" | " + total);
                }
            }
            sw.Dispose();
            return total;
        }

        static char GetFirstFigure(string line)
        {
            int posFirst = line.Length;
            char firstFigure = new char();
            foreach (var item in dic.Keys)
            {
                if (line.Contains(item) && posFirst > line.IndexOf(item))
                {
                    firstFigure = dic.GetValueOrDefault(item);
                    posFirst = line.IndexOf(item);
                }
            }
            if (line.IndexOf(line.First(c => char.IsNumber(c))) < posFirst)
            {
                firstFigure = line.First(c => char.IsNumber(c));
            }

            return firstFigure;
        }

        static char GetLastFigure(string line)
        {
            int posLast = 0;
            char lastFigure = new char();
            foreach (var item in dic.Keys)
            {
                if (line.Contains(item) && posLast < line.IndexOf(item))
                {
                    lastFigure = dic.GetValueOrDefault(item);
                    posLast = line.IndexOf(item);
                }
            }
            if (line.IndexOf(line.First(c => char.IsNumber(c))) > posLast)
            {
                lastFigure = line.First(c => char.IsNumber(c));
            }
            return line.Last(c => char.IsNumber(c));
        }
        static int GetNumber(string line, StreamWriter sw)
        {
            string newLine = GetNewLine(line);
            int i = int.Parse(string.Concat(GetFirstFigure(line), GetLastFigure(line)));
            sw.Write(newLine + " | " + i);
            return i;
        }

        static string GetNewLine(string line)
        {
            string newLine = line;
            int pos;
            int posFirst = line.Length;
            int posLast = 0;
            string first = "";
            string last = "";

            Dictionary<string, int> dic = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };
            foreach (var ns in dic.Keys)
            {
                if (newLine.Contains(ns))
                {
                    pos = newLine.IndexOf(ns);
                    if (pos < posFirst)
                    {
                        posFirst = newLine.IndexOf(ns);
                        first = ns;
                    }
                    if (pos > posLast)
                    {
                        posLast = newLine.IndexOf(ns);
                        last = ns;
                    }
                }
            }

            if (!string.IsNullOrEmpty(first))
                newLine = newLine.Replace(first, dic.GetValueOrDefault(first).ToString());
            if (!string.IsNullOrEmpty(last))
                newLine = newLine.Replace(last, dic.GetValueOrDefault(last).ToString());
            return newLine;
        }
    }
}
