// See https://aka.ms/new-console-template for more information
using System.Threading;

Console.WriteLine(GetCalibrationSum());

static int GetCalibrationSum()
{
    int total  = 0;
    var sw = new StreamWriter(@"C:\Users\310616706\source\repos\AdventOfCode2023\AdventOfCode2023\Output.txt");
    using (var sr = new StreamReader(@"C:\Users\310616706\source\repos\AdventOfCode2023\AdventOfCode2023\Input.txt"))
    {
        while(!sr.EndOfStream)
        {
            
            total += GetNumber(sr.ReadLine(), sw);
            sw.WriteLine(" | " + total);
        }
    }
    sw.Dispose();
    return total;
}
static int GetNumber(string line, StreamWriter sw)
{
    string newLine = GetNewLine(line);
    int i = int.Parse(string.Concat(newLine.First(c => Char.IsNumber(c)), newLine.Last(c => Char.IsNumber(c))));
    sw.Write(newLine + " | " + i);
    return i;
}

static string GetNewLine(string line)
{
    string newLine = line;
    int pos;
    int posFirst = line.Length;
    int posLast = 0;
    string first="";
    string last="";
    
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

    if(!string.IsNullOrEmpty(first))
        newLine = newLine.Replace(first, dic.GetValueOrDefault(first).ToString());
    if (!string.IsNullOrEmpty(last))
        newLine = newLine.Replace(last, dic.GetValueOrDefault(last).ToString());
    return newLine;
}
